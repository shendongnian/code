    System.Timers.Timer timer;
    public YourConstructor()
    {
        InitializeComponent();
        // Create a timer with a ten second interval.
        timer = new System.Timers.Timer(10000);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += OnTimedEvent;
        // Raise the Elapsed event only once.
        timer.AutoReset = false;
        // Start the timer.
        timer.Start();
    }
    private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
        // Mouse has not moved for 10s.
    }
    private void Grid_MouseMove(object sender, MouseEventArgs e)
    {
        // Reset the timer.
        if(timer.Enabled)
        {
            timer.Stop();
        }
        timer.Start();
    }
