    GeoCoordinateWatcher.PositionChanged += GeoCoordinateWatcherPositionChanged;
    private void GeoCoordinateWatcherPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
    {
    	var currentLatitude = e.Position.Location.Latitude;
    	var currentLongitude = e.Position.Location.Longitude;
    }
