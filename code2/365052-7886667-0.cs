       // Code from Form 1
     public partial class Form1 : Form
    {
        public void PassValue(string strValue)
        {
            label1.Text = strValue;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 objForm2 = new Form2(this);
            objForm2.Show();
        }![Application Screen Shot][1]
    
    }
    
    // Code From Form 2
    
    public partial class Form2 : Form
    {
        Form1 ownerForm = null;
    
        public Form2(Form1 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {       
            this.ownerForm.PassValue(textBox1.Text);
            this.Close();
        }
    }
