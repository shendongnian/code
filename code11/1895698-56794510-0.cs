    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FindRadioButtons(this);
        }
        private List<RadioButton> RadioButtons = new List<RadioButton>();
        private void FindRadioButtons(Control curControl)
        {
            foreach(Control subControl in curControl.Controls)
            {
                if (subControl is RadioButton)
                {
                    RadioButton rb = (RadioButton)subControl;
                    rb.CheckedChanged += Rb_CheckedChanged;
                    RadioButtons.Add(rb);
                }
                else if(subControl.HasChildren)
                {
                    FindRadioButtons(subControl);
                }
            }
        }
        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton source = (RadioButton)sender;
            if (source.Checked)
            {
                RadioButtons.Where(rb => rb != source).ToList().ForEach(rb => rb.Checked = false);
            }          
        }
    }
