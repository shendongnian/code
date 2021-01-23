        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !CustomTB.SuppressEscape)
            {
                this.Close();
            }
            CustomTB.SuppressEscape = false;
        }
