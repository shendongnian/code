    private void MainLoop(object state)
    {
      try
      {
        // Do something and then tell Timer to wait for a second
      }
      finally
      {
        _timer.Change(1000, Timeout.Infinite);
      }
    }
