        public Form MainForm = null;
        public Sample(ref Form mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
        private void Sample_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Show();
        }
