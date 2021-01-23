        private readonly DispatcherTimer _dispatcherTimer;
        public MyClass()
        {
            InitializeComponent();
            WBrowser.Navigate(loginUri);
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            _dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (WBrowser.IsLoaded && WBrowser.Source == null)
            {
                _dispatcherTimer.Stop();
                Close();
            }
        }
