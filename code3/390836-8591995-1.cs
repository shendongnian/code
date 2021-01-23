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
            timer.Stop(); // you don't want any more ticking. timer will start again when mouse moves.
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // restart timer. will not cause ticks.
            timer.Stop();
            timer.Start();
        } 
