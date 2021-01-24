    public void ReadDataFromUsb()
    {
      var timer = new System.Timers.Timer(40);
      timer.Elapsed += ReadNextDataBlockAsync;
    }
    
    public async void ReadNextDataBlockAsync(Object source, ElapsedEventArgs e)
    {
      await Task.Run(BeginReading);
    }
    private void BeginReading()
    {
      BatchUpdate();
    }
