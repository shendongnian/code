    {
         private string str;
        public string passvalue
        {
            get { return  str; }
            set { str = value; }
        }
    
        public Form2()
        {
            InitializeComponent();
        }
        private void Btn_Ok1_Click(object sender, EventArgs e)
        {
            passvalue = textBox1.Text;
            this.Close();
        }
    }
