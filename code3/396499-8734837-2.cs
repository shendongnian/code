    const int DATAREFRESH = 15000;
    private Timer _timer;
    
    void RequestUpdate()
    {
        // Set the timer
        _timer = new Timer(TimeOutCallback, null, 0, DATAREFRESH);
    }
    
    private void TimeOutCallback(object state)
    {
        // Some data processing goes here
        Console.WriteLine("Update");
    }
