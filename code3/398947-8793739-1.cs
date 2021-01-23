        System.Timers.Timer timer;
        Stopwatch stopwatch;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            stopwatch = new Stopwatch();
        }
        public void TimerElapsed(object sender, EventArgs e)
        {
            TextBoxStopWatch.Text = Convert.ToString(stopwatch.Elapsed);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            stopwatch.Start();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            TextBoxStopWatch.Text = "00:00:000";
            timer.Stop();
            stopwatch.Reset();
            stopwatch.Stop();
        }
