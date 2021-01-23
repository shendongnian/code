    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }
        void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (Environment.HasShutdownStarted)
            {
                MessageBox.Show("Total amount of time the system logged on:" + ClockTextBlock.Text);
            }
        }
        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                // ...
                case SessionSwitchReason.SessionLock:
                    if (stopWatch.IsRunning)
                        stopWatch.Stop();                    
                    break;
                case SessionSwitchReason.SessionUnlock:
                    stopWatch.Start();
                    dt.Start();
                    break;
                case SessionSwitchReason.SessionLogoff:
                    MessageBox.Show("Total amount of time the system logged on:" + ClockTextBlock.Text);
                    break;
                // ...
            }
        }
        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                ClockTextBlock.Text = currentTime;
            }
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            dt.Start();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
                stopWatch.Stop();
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Reset();
            stopWatch.Start();
        }
    }
