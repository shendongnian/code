    // Create a Timer with a Normal Priority
    _timer = new DispatcherTimer();
    
    // Set the Interval to 2 seconds
    _timer.Interval = TimeSpan.FromMilliseconds(2000); 
    
    // Set the callback to just show the time ticking away
    // NOTE: We are using a control so this has to run on 
    // the UI thread
    _timer.Tick += new EventHandler(delegate(object s, EventArgs a) 
    { 
        statusText.Text = string.Format(
            "Timer Ticked:  {0}ms", Environment.TickCount); 
    });
    
    // Start the timer
    _timer.Start();
