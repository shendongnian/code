        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!suppress)
            {
                this.Close();
            }
            suppress = false;
        }
        bool suppress = false;
        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                suppress = true;
            }
        }
