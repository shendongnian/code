    public struct GeoCoordinate
    {
        private readonly double latitude;
        private readonly double longitude;
    
        public double Latitude { get { return latitude; } }
        public double Longitude { get { return longitude; } }
        public GeoCoordinate(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    
        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
    }
