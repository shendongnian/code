    async Task StartListening()
    {
        await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true, new Plugin.Geolocator.Abstractions.ListenerSettings
        {
            ActivityType = 
            Plugin.Geolocator.Abstractions.ActivityType.AutomotiveNavigation,
            AllowBackgroundUpdates = true,
            DeferLocationUpdates = true,
            DeferralDistanceMeters = 1,
            DeferralTime = TimeSpan.FromSeconds(1),
            ListenForSignificantChanges = true,
            PauseLocationUpdatesAutomatically = false
        });
        CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
    }
    private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            var Position = e.Position;
        });
    } 
