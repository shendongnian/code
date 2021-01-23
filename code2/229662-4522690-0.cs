        public SO4522583()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
            DataContext = this;
        }
        private bool _notified = false;
        private DispatcherTimer _timer;
        void _timer_Tick(object sender, EventArgs e)
        {
            _notified = false;
        }
        ...
        long counter;
        public long Counter
        {
            get { return counter; }
            set
            {
                if (counter != value)
                {
                    counter = value;
                    if (!_notified)
                    {
                        _notified = true;
                        OnPropertyChanged("Counter");
                    }
                }
            }
        }
