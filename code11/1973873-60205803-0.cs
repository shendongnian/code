    public class Location
    {
        public double Latitude { get; set; }  // degrees from -90 to 90
        public double Longitude { get; set; } // degrees from -180 to 180
    }
    public const double Wgs84EquatorialRadius = 6378137d;
    public const double Wgs84MetersPerDegree = Wgs84EquatorialRadius * Math.PI / 180d;
    public override Point LocationToPoint(Location location)
    {
        return new Point(
            Wgs84MetersPerDegree * location.Longitude,
            Wgs84MetersPerDegree * LatitudeToY(location.Latitude));
    }
    public override Location PointToLocation(Point point)
    {
        return new Location(
            YToLatitude(point.Y / Wgs84MetersPerDegree),
            point.X / Wgs84MetersPerDegree);
    }
    public static double LatitudeToY(double latitude)
    {
        if (latitude <= -90d)
        {
            return double.NegativeInfinity;
        }
        if (latitude >= 90d)
        {
            return double.PositiveInfinity;
        }
        return Math.Log(Math.Tan((latitude + 90d) * Math.PI / 360d)) * 180d / Math.PI;
    }
    public static double YToLatitude(double y)
    {
        return 90d - Math.Atan(Math.Exp(-y * Math.PI / 180d)) * 360d / Math.PI;
    }
