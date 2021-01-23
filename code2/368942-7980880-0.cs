    // Code from Form 1
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 objForm2 = new Form2();
            objForm2.ChangeStatus += new ChangeStatusHandler(objForm2_ChangeStatus);
            objForm2.Show();
        }
        public void objForm2_ChangeStatus(string strValue)
        {
            statusbar.Text = strValue;
        }
    }
    
    // Code From Form 2
    public delegate void ChangeStatusHandler(string strValue);
    public partial class Form2 : Form
    {
        public event ChangeStatusHandler ChangeStatus;
    
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (PassValue != null)
            {
                PassValue(textBox1.Text);
            }
        }
    }
