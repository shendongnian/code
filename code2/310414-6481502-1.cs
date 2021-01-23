    public static void Main()
    {
      var latch = new AutoResetEvent(false);
    
      new Thread(
        () =>
        {
          latch.WaitOne(); // Wait for the latch.
        }).Start();
    
      latch.Set(); // Release the latch.
    }
