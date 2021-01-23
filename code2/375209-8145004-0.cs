    public partial class ComboBoxTrialForm : Form
    {
        public ComboBoxTrialForm()
        {
            InitializeComponent();
        }
    
        public void ShowForm(string comboBoxValue)
        {
            this.Show();
    
            List<string> streets = new List<string>() { "Main St.", "First St.", "Second St." };
            comboBox1.DataSource = streets;
    
            SetComboTextValue(comboBoxValue);
        }
    
        public void SetComboTextValue(string text)
        {
            comboBox1.Text = text;
        }
    }
