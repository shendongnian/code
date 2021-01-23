        var timer = new System.Timers.Timer();
        // Hook up the Elapsed event for the timer using a lambda
        timer.Elapsed += (o, e) => Console.WriteLine("Timer elapsed");
        // Set the Interval to 100 ms
        timer.Interval = 100;
 
        // Start the timer.
        timer.Enabled = true;
   
