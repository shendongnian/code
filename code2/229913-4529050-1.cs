    var t = new Timer(TimerCallback);
    
    // Figure how much time until 4:00
    DateTime now = DateTime.Now;
    DateTime fourOClock = DateTime.Today.AddHours(16.0);
    // If it's already past 4:00, wait until 4:00 tomorrow    
    if (now > fourOClock)
    {
        fourOClock = fourOClock.AddDays(1.0);
    }
    
    int msUntilFour = (int)((fourOClock - now).TotalMilliseconds);
    
    // Set the timer to elapse only once, at 4:00.
    t.Change(msUntilFour, Timeout.Infinite);
