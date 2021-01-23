        public partial class Form1 : Form
        {
            public static Form1 Form1Instance;
    
            public Form1()
            {
                //Everyone eveywhere in the app show know me as Form1.Form1Instance
                Form1Instance = this;
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //Make sure I am kept hidden
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Visible = false;
    
                //Open another form 
                var form2 = new Form2
                {
                    //since we open it from a minimezed window - it will not be focused unless we put it as TopMost.
                    TopMost = true
                };
                form2.Show();
                //now that that it is topmost and shown - we want to set its behavior to be normal window again.
                form2.TopMost = false; 
            }
        }
        
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                Form1.Form1Instance.Close();
            }
        }
