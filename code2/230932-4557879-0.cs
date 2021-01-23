        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Text = DateTime.Now.ToString();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.textBox1.Focused)
            {
                this.Close();
            }
        }
