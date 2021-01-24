    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        public void SetTextBoxValue(string val)
        {
            this.textBox1.Text = val;
        }
        private void CreateForm2()
        {
             var form2 = new Form2(this);
             form2.Show();
        }
    }
    
    public partial class Form2: Form
    {
        private Form1 form1;
    
        public Form2(Form1 frm1)
        {
            InitializeComponent();
    
            form1= frm1;
            form1.SetTextBoxValue("Value from Form2");
        }   
    }
