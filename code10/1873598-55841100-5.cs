	public partial class Form1 : Form
	{
		DinnerParty lanparty = null;
	
		public Form1()
		{
			InitializeComponent();
		}
	
		private void Form1_Load(object sender, EventArgs e)
		{
			lanparty = new DinnerParty((int)NumberUpDown1.Value, CheckBoxHealth.Checked, CheckBoxDecotations.Checked);
			lanparty.CostUpdated += lanparty_CostUpdated;
			DisplayDinnerPartyCost();
		}
	
		private void lanparty_CostUpdated(object sender, EventArgs e)
		{
			DisplayDinnerPartyCost();
		}
		
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			lanparty.NumberOfPeople = (int)NumberUpDown1.Value;
		}
	
		private void CheckBoxDecotations_CheckedChanged(object sender, EventArgs e)
		{
			lanparty.FancyDecorations = CheckBoxDecotations.Checked;
		}
	
		private void CheckBoxHealth_CheckedChanged(object sender, EventArgs e)
		{
			lanparty.HealthyOption = CheckBoxHealth.Checked;
		}
	
		public void DisplayDinnerPartyCost()
		{
			decimal cost = lanparty.Cost;
			labelRetrunCost.Text = cost.ToString("c");
		}
	}
