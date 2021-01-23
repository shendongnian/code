    const int DATAREFRESH = 15000;
    
    void RequestUpdate()
    {
        // Set the timer
        Timer t = new Timer(TimeOutCallback, null, 0, DATAREFRESH);
    }
    
    private void TimeOutCallback(object state)
    {
        // Some data processing goes here
        Console.WriteLine("Update");
    }
