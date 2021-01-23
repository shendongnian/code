    public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
    
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you wan't to close this app", "Question", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                e.Cancel = true;
        }
        
