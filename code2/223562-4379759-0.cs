    System.Timers.Timer aTimer = new System.Timers.Timer(10000); //10 seconds
    
    // Hook up the Elapsed event for the timer.
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    aTimer.Enabled = true; // Starts the Timer
    
    // Specify what you want to happen when the Elapsed event is raised
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //Perform update
    }
