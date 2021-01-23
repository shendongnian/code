        private readonly DispatcherTimer _dispatcherTimer;
        public MyClass()
        {
            InitializeComponent();
            WBrowser.Navigate(loginUri);
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            _dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (WBrowser.Source == null)
            {
                _dispatcherTimer.Stop();
                Close();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (_dispatcherTimer.IsEnabled)
            {
                _dispatcherTimer.Stop();
            }
        }
        private void WBrowser_OnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if(!_dispatcherTimer.IsEnabled)
            {
                _dispatcherTimer.Start();
            }
        }
