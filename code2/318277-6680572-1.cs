    private void MainLoop(object state)
    {
      _lastRunTime = DateTime.UtcNow;
      try
      {
        // Do something and then tell Timer to wait for a second
      }
      finally
      {
        _timer.Change(1000, Timeout.Infinite);
      }
    }
