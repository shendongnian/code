    public void ReadDataFromUsb()
    {
      var timer = new System.Timers.Timer(40);
      timer.Elapsed += ReadNextDataBlockAsync;
    }
    
    // Will be invoked every 40 ms by the timer
    public async void ReadNextDataBlockAsync(Object source, ElapsedEventArgs e)
    {
      await Task.Run(BeginReading);
    }
    private void BeginReading()
    {
      // Read from data source
    }
