        //Create this variable
        private bool _saved = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSomething();
            _saved = true;
        }
        //Raised when the text is changed. I just put this for demonstration purpose.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _saved = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_saved == false)
            {
                var result = MessageBox.Show("Are you sure you want to close?\nYou may have unsaved information", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    _saved = true;
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
        }
