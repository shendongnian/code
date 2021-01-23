        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            var position = Mouse.GetPosition(this);
            // position.X
            // position.Y
            // timer.Stop() if you don't want to continue ticking.
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
            timer.Start();
        } 
