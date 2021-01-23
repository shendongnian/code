    public partial class Form2 : Form
        {
            Form parentForm;
            public Form2()
            {
                InitializeComponent();
            }
    
            public void setParent(Form value)
            {
                parentForm = value;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                parentForm.Show();
                this.Close();
            }
        }
