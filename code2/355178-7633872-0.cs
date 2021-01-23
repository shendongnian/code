    // Start
    thread = new Thread(new ThreadStart(YourCommand));
    thread.Start();
    // Pause
    if (thread != null)
    {
    thread.Suspend();
    }
    //Continue
    if (thread != null)
    {
    thread.Resume();
    }
    //Alive
    if (thread != null)
    {
        if (thread.IsAlive)
        {
         thread.Abort();
        }    
    }
  
