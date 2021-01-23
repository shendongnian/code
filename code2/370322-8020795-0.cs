    const int TimerFrequency = 50;  // or whatever
    System.Threading.Timer timer;
    void InitTimer()
    {
        timer = new System.Threading.Timer(TimerCallback, null, TimerFrequency, Timeout.Infinite);
    }
    
    void TimerCallback(object state)
    {
        // do your stuff here
        // Now reset the timer
        timer.Change(TimerFrequency, Timeout.Infinite);
    }
