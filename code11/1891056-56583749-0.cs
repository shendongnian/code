    Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
       
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
        }
        int lastNotify = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Hour == 16 && lastNotify != 16) || (DateTime.Now.Hour == 21 && lastNotify != 21))
            {
                this.notifyIcon1.BalloonTipText = "Whatever";
                this.notifyIcon1.BalloonTipTitle = "Title";
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(3);
                
                lastNotify = DateTime.Now.Hour;
            }
        }
