	public Form1()
	{
		InitializeComponent();
	}
	private void Form1_Load(object sender, EventArgs e)
	{
		lanparty = new DinnerParty((int)NumberUpDown1.Value, CheckBoxHealth.Checked, CheckBoxDecotations.Checked);
		DisplayDinnerPartyCost();
	}
