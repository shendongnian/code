    private Timer t;
    public MainWindow()
    {
        InitializeComponent();
        t = new Timer(1000);
        t.Elapsed += Timer_OnElapsed;
    }
    
    private void Timer_OnElapsed(object sender, ElapsedEventArgs e)
    {
        Application.Current.Dispatcher?.Invoke(() =>
        {
            Popup1.IsOpen = true;
        });
    }
