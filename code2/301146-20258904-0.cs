    {
        public readonly Form1 _form1;
        public Form_2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
 
        }         
 
        private void Form2(object sender, EventArgs e)
        {     
                                    
            _form1.Remark = txtbx_remark.Text;                  
            
        }// Remark is a string in Form1 .... 
