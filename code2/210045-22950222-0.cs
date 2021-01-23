        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                testProgressBar.Minimum = 0;
                testProgressBar.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                testProgressBar.Value = mediaPlayer.Position.TotalSeconds;
            }
        }
