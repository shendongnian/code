    Console.WriteLine($"IsHighResolution = {HighResolutionTimer.IsHighResolution}");
    Console.WriteLine($"Tick time length = {HighResolutionTimer.TickLength} [ms]");
    var timer = new HighResolutionTimer(0.5f);
    
    // UseHighPriorityThread = true, sets the execution thread 
    // to ThreadPriority.Highest.  It doesn't provide any precision gain
    // in most of the cases and may do things worse for other threads. 
    // It is suggested to do some studies before leaving it true
    timer.UseHighPriorityThread = false;
    
    timer.Elapsed += (s, e) => { /*...*/ }; // The call back
    timer.Start();  
    timer.Stop();    // by default Stop waits for thread.Join()
                     // which, if called not from Elapsed subscribers,
                     // would mean that all Elapsed subscribers
                     // are finished when the Stop function exits 
    timer.Stop(joinThread:false)   // Use if you don't care and don't want to wait
             
