    ShowPoup(); 
    if (_watcher == null)
    {
        _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        _watcher.MovementThreshold = 15; // use MovementThreshold to ignore noise in the signal
        _watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
    }
    
    System.Threading.ThreadPool.QueueUserWorkItem((ignored) =>
    {
        if (!_watcher.TryStart(true, TimeSpan.FromSeconds(3)))
        {
            Dispatcher.BeginInvoke(() =>
            {
                HidePopup();
                MessageBox.Show("Please turn on location services on device under Settings.");
            }
        });
    });
