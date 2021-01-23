    public partial class Form1 : Form
    {
        public void CreateForm2()
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }
        public string MyTextboxText
        {
            get { return txtMyTextbox.Text; }
            set { txtMyTextbox.Text = value; }
        }
    }
    public partial class Form2 : Form
    {
        private Form1 parentForm;
        public Form2(Form1 parentForm)
        {
            this.parentForm = parentForm;
        }
        public void myButtonClick() 
        {
            parentForm.MyTextboxText = "Hello";
        }
    }
