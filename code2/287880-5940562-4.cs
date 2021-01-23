    public void SomeMethod()
    {
      while (!yourEvent.WaitOne(POLLING_INTERVAL))
      {
        if (IsShutdownRequested())
        {
          // Add code to end gracefully here.
        }
      }
      // Your event was signaled so now we can proceed.
    }
