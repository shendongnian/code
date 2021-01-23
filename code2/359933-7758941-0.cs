    public class GeocodedPosition
    {
        private double lat;
        private double lon;
        public GeocodedPosition(double latitude, double longitude)
        {
            lat = latitude;
            lon = longitude;
        }
        public double Latitude
        {
            get
            {
                return lat;
            }
        }
        public double Longitude
        {
            get
            {
                return lon;
            }
        }
    }
