    // using System.Device.Location;
    
    GeoCoordinate c1 = new GeoCoordinate(36.578581, -118.291994);
    GeoCoordinate c2 = new GeoCoordinate(36.23998, -116.83171);
    double distanceInKm = c1.GetDistanceTo(c2) / 1000;
    // Your result is: 136,111419742602
