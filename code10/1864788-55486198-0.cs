    bool abort = false;
    GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
    if (watcher.TryStart(false, TimeSpan.FromMilliseconds(3000)))
    {
        DateTime start = DateTime.Now;
        while(watcher.Status != GeoPositionStatus.Ready && !abort)
        {
            Thread.Sleep(200);
            if(DateTime.Now.Subtract(start).TotalSeconds > 5)
                abort = true;
        }
    
        GeoCoordinate coord = watcher.Position.Location;
        if (!coord.IsUnknown)
        {
            Printer.Print(String.Format("Current Lat: {0}, Current Long: {1}", coord.Latitude, coord.Longitude));
        }
        else // Path taken most often
        {
            throw new CommandException("Weather data unknown. (Are location services enabled?)"); 
        }
    }
    else
    {
        throw new CommandException("Weather data unknown. (Are location services enabled?)");
    }
