    public struct Coordinate
    {
        public Coordinate(double latitude, double longitude) : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
