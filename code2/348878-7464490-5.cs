    // Create the timer
    System.Timers.Timer aTimer = new System.Timers.Timer(10000);
    
    // Hook up the Elapsed event for the timer.
    aTimer.Elapsed += new ElapsedEventHandler(OnPrintSimulationResult);
    // Change the Interval to change the speed of the simulation
    aTimer.Interval = 2000; // <-- Allows you to control the speed of the simulation
    aTimer.Enabled = true;
