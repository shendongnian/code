        public FrmLogin()
        {
            InitializeComponent();
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
