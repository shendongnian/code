    DateTime targetDate = GetActionTime(); // whatever
    
    // compute the difference between targetDate and now.
    // we use UTC so that automatic time changes (like daylight savings) don't affect it
    TimeSpan delayTime = targetDate.ToUniversalTime() - DateTime.UtcNow;
    
    // Now create a timer that waits that long ...
    Timer t = new Timer(TimerProc, null, delayTime, TimeSpan.FromMilliseconds(-1));
