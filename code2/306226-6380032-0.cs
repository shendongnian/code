    // set up timer
    Timer timer = new Timer(...);
    ...
    
    // stop timer
    timer.Dispose();
    timer = null;
    ...
    
    // timer callback
    {
      if (timer != null)
      {
        ..
      }
    }
