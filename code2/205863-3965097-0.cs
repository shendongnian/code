        public Form1()
        {
            InitializeComponent();
        }
        private bool DrawText = false;
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.ShowMoreActions)
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            
        }
