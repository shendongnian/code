    public class GeocodeCalculator
    {
        private const int earthRadiusMiles = 3960;
        private const int earthRadiusKilometers = 6371;
        public enum DistanceType
        {
            Miles,
            Kilometers
        }
        /// <summary>
        /// Uses the Haversine formula to calculate the distance between two locations
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <param name="type"></param> 
        /// <returns></returns>
        public double Distance(GeocodedPosition PositionA, GeocodedPosition PositionB, DistanceType type)
        {
            double r = (type.Equals(DistanceType.Miles)) ? earthRadiusMiles : earthRadiusKilometers;
            double dLat = ToRadian(PositionB.Latitude - PositionA.Latitude);
            double dLon = ToRadian(PositionB.Longitude - PositionA.Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadian(PositionA.Latitude)) * Math.Cos(ToRadian(PositionB.Latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = r * c;
            return d;
        }
        /// <summary>
        /// Convert to Radians
        /// </summary>
        /// <param name=”val”></param>
        /// <returns></returns>
        private double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
