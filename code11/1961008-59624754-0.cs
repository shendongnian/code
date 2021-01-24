    bool stopLoop = false;
    
    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Interval = TimeSpan.FromSeconds(30);
    timer.Elapsed += (s, e) => stopLoop = true;
    timer.Start();
