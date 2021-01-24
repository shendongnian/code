    // insert this into a long running function, and scope the timer variable correctly 
    System.Timers.Timer myTimer = new System.Timers.Timer();
    myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    myTimer.Interval = 600000;
    myTimer.Enabled = true;
       
     // Define what you want to happen when the Elapsed event occurs (happens on the interval you set).
     private static void OnTimedEvent(object source, ElapsedEventArgs e)
     {
         //do some work here
     }
