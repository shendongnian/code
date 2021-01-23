    long counter = 0;
    
    void ThreadEntryPoint()
    {
      try
      {
        ...
        //
      }
      finally
      {
        // Decrement counter
        Interlocked.Decrement(ref counter);
      }
    }
    
    void MainThread()
    {
      // Start worers
      for(...)
      {
        // Increment threads couter
        Interlocked.Increment(ref counter);
        ((Action)ThreadEntryPoint).BeginInvoke(null, null);
      }
    
      // Wait until counter is equal to 0
      while(Interlocked.Read(ref counter) != 0)
      {
        Thread.Sleep(0);
      }
    }
