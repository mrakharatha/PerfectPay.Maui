namespace PerfectPay;

public partial class MainPage : ContentPage
{
	private decimal _bill;
	private int _tip;
	private int _noPersons = 1;
	public MainPage()
	{
		InitializeComponent();
	}

	private void TxtBill_OnCompleted(object sender, EventArgs e)
	{
		_bill = decimal.Parse(TxtBill.Text);
		Calculate();
	}

	private void Calculate()
	{
		var totalTip = (_bill * _tip) / 100;

		var tipPerPerson = totalTip / _noPersons;

		LblTipPerson.Text = $"{tipPerPerson:C}";

		var subTotal = _bill / _noPersons;
		LblSubTotal.Text = $"{subTotal:C}";

		var total = tipPerPerson + subTotal;
		LblTotal.Text = $"{total:C}";
	}

	private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
	{
		_tip=(int)SldTip.Value;
		LblTip.Text = $"Tip: {_tip}%";
		Calculate();
	}

	private void BtnMinus_OnClicked(object sender, EventArgs e)
	{
		if(_noPersons==1)
			return;

		_noPersons--;
		LblNoPersons.Text= _noPersons.ToString();
		Calculate();
	}

	private void BtnPlus_OnClicked(object sender, EventArgs e)
	{
		_noPersons++;
		LblNoPersons.Text = _noPersons.ToString();
		Calculate();
	}

	private void Button_OnClicked(object sender, EventArgs e)
	{
		var btn = (Button)sender;
		var percentage = int.Parse(btn.Text.Replace("%", ""));
		SldTip.Value=percentage;
	}
}

