    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        private void form1Button_Click(object sender, EventArgs e)
        {
            form2.Show(this);
        }
        private void form1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            form2.ChangeCheck(form1CheckBox.Checked);
        }
        public void ChangeCheck(bool isItChecked)
        {
            form1CheckBox.Checked = isItChecked;
        }
    }
