    public MapView()
    {
        InitializeComponent();
        geoDestination = new GeoCoordinate(54.975556, -1.621667);
        geoCurrentLocation = new GeoCoordinate(53.463056, -2.291389);
        CreatePushpins();
        DataContext = this;
    }
