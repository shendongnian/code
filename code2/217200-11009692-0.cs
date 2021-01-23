        public MainForm(string[] args)
        {
            InitializeComponent();
            // tabControl1.SelectedIndex = 2; // Did not fire
            OnceAtStartupTimer.Enabled = true;
        }
        private void OnceAtStartupTimer_Tick(object sender, EventArgs e)
        {
            OnceAtStartupTimer.Enabled = false;
            tabControl1.SelectedIndex = 2;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Code to run when SelectedIndex changes            
        }
