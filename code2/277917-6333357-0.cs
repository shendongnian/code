    public void WaitingThread()
    {
      lock (mylock)
      {
        while (!CanProceed())
        {
          Monitor.Wait(mylock);
        }
        // The wait condition is finally satisfied so we can proceed now.
      }
    }
