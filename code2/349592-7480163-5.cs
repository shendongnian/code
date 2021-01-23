    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void form2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ((Form1)this.Owner).ChangeCheck(form2CheckBox.Checked);
        }
        public void ChangeCheck(bool isItChecked)
        {
            form2CheckBox.Checked = isItChecked;
        }
    }
