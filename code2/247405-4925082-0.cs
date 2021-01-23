        public Form1() {
            InitializeComponent();
            Application.Idle += new EventHandler(Application_Idle);
        }
        void Application_Idle(object sender, EventArgs e) {
            bthFinish.Enabled = checkBlinna.Checked || checkSoup.Checked || checkGnocchi.Checked;
        }
