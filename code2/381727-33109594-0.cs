        public MainWindow()
        {
            InitializeComponent();
            TheCallDelegate = TheCall;
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        DispatcherTimer _timer = null;
        
        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Dispatcher.BeginInvoke(TheCallDelegate);            
        }
        Action TheCallDelegate;
        void TheCall()
        {
            Window win = new Window();
            win.ShowDialog();
        }
