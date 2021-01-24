    public async Task StartCasting(CastingDisplay castee)
    {
       //When a device is selected, first thing we do is stop the watcher so it's search doesn't conflict with streaming
       if (miraDeviceWatcher.Status != DeviceWatcherStatus.Stopped)
       {
          miraDeviceWatcher.Stop();
       }
       //Create a new casting connection to the device that's been selected
       connection = castee.Device.CreateCastingConnection();
       //Register for events
       connection.ErrorOccurred += Connection_ErrorOccurred;
       connection.StateChanged += Connection_StateChangedAsync;
       var image = new Windows.UI.Xaml.Controls.Image();
       await connection.RequestStartCastingAsync(image.GetAsCastingSource());
    }
