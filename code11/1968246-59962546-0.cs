        // Create a timer with a two second interval.
        timer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
