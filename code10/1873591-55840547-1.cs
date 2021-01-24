    namespace DinnerParty
    {
        public partial class Form1 : Form
        {
            DinnerParty lanparty = null;
            public Form1()
            {
                InitializeComponent();
            }
            // Make sure to add event handler for Load
            private void Form1_Load(object sender, EventArgs e)
            {
                lanparty = new DinnerParty((int)NumberUpDown1.Value,
                                           CheckBoxHealth.Checked,
                                           CheckBoxDecotations.Checked);
                GetLanPartyConfiguration();
                DisplayDinnerPartyCost();
            }
            // Make sure that any code that references lanparty does not execute while it is null
            public void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {
                if (lanparty != null)
                {
                    lanparty.NumberOfPeople = (int) NumberUpDown1.Value;
                    DisplayDinnerPartyCost();    
                }
            }
            public void CheckBoxDecotations_CheckedChanged(object sender, EventArgs e)
            {
                if (lanparty != null)
                {
                    lanparty.FancyDecorations = CheckBoxDecotations.Checked;
                    DisplayDinnerPartyCost();
                }
            }
            public void CheckBoxHealth_CheckedChanged(object sender, EventArgs e)
            {
                if (lanparty != null)
                {
                    lanparty.HealthyOption = CheckBoxHealth.Checked;
                    DisplayDinnerPartyCost();
                }
            }
            // You may need a functions like this, depending on how your code works
            private void GetLanPartyConfiguration()
            {
                if (lanparty != null)
                {
                    lanparty.NumberOfPeople = (int) NumberUpDown1.Value;
                    lanparty.HealthyOption = CheckBoxHealth.Checked;
                    lanparty.FancyDecorations = CheckBoxDecotations.Checked;
                }
            }
            private void SetLanPartyControls()
            {
                if (lanparty != null)
                {
                    NumberUpDown1.Value = lanparty.NumberOfPeople;
                    CheckBoxHealth.Checked = lanparty.HealthyOption;
                    CheckBoxDecotations.Checked = lanparty.FancyDecorations;
                }
            }
            public void DisplayDinnerPartyCost()
            {
                if (lanparty != null)
                {
                    decimal cost = lanparty.Cost;
                    labelRetrunCost.Text = cost.ToString("c");
                }
            }
        }
    }
