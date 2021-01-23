        public MainPage()
        {
            InitializeComponent();
            if (someVariable == 0)
            {
                myPopup = new Popup() { IsOpen = true, Child = new AnimatedSplashScreen() };
                backroungWorker = new BackgroundWorker();
                RunBackgroundWorker();
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(10);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
                someVariable = 1;
            }
            
        }
        #region timer
        void timer_Tick(object sender, EventArgs e)
        {
            if (imagesScrollview.HorizontalOffset == (listBox.ActualWidth - 483))
                imagesScrollview.ScrollToHorizontalOffset(10);
           imagesScrollview.ScrollToHorizontalOffset(imagesScrollview.HorizontalOffset +1);
            current = imagesScrollview.HorizontalOffset + 1;
