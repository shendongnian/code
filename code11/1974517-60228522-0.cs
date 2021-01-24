    public MainWindow()
    {
        InitializeComponent();
        DataContext = this; //<--
        myValue = false;
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += timer_Tick;
        timer.Start();
    }
