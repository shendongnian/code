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
                DisplayDinnerPartyCost();
            }
        }
    }
