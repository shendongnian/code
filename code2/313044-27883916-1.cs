    // Haversine formula to calculate great-circle distance between two points on Earth
    
        private const double _radiusEarthMiles = 3959;
        private const double _radiusEarthKM = 6371;
        private const double _m2km = 1.60934;
        private const double _toRad = Math.PI / 180;
    
        /// <summary>
        /// Haversine formula to calculate 
        /// great-circle (orthodromic) distance on Earth 
        /// High Accuracy, Medium speed
        /// </summary>
        /// <param name="Lat1">double: 1st point Latitude</param>
        /// <param name="Lon1">double: 1st point Longitude</param>
        /// <param name="Lat2">double: 2nd point Latitude</param>
        /// <param name="Lon2">double: 2nd point Longitude</param>
        /// <returns>double: distance in miles</returns>
        public static double DistanceMilesHaversine(double Lat1,
                                                    double Lon1,
                                                    double Lat2,
                                                    double Lon2)
        {
            try
            {
                double _radLat1 = Lat1 * _toRad;
                double _radLat2 = Lat2 * _toRad;
                double _dLatHalf = (_radLat2 - _radLat1) / 2;
                double _dLonHalf = Math.PI * (Lon2 - Lon1) / 360;
    
                // intermediate result
                double _a = Math.Sin(_dLatHalf);
                _a *= _a;
    
                // intermediate result
                double _b = Math.Sin(_dLonHalf);
                _b *= _b * Math.Cos(_radLat1) * Math.Cos(_radLat2);
    
                // central angle, aka arc segment angular distance
                double _centralAngle = 2 * Math.Atan2(Math.Sqrt(_a + _b), Math.Sqrt(1 - _a - _b));
    
                // great-circle (orthodromic) distance on Earth between 2 points
                return _radiusEarthMiles * _centralAngle;
            }
            catch { throw; }
        }
    
    // Spherical law of cosines formula to calculate great-circle distance between two points on Earth
    
           /// <summary>
            /// Spherical Law of Cosines formula to calculate 
            /// great-circle (orthodromic) distance on Earth;
            /// High Accuracy, Medium speed
            /// http://en.wikipedia.org/wiki/Spherical_law_of_cosines
            /// </summary>
            /// <param name="Lat1">double: 1st point Latitude</param>
            /// <param name="Lon1">double: 1st point Longitude</param>
            /// <param name="Lat2">double: 2nd point Latitude</param>
            /// <param name="Lon2">double: 2nd point Longitude</param>
            /// <returns>double: distance in miles</returns>
            public static double DistanceMilesSLC(  double Lat1, 
                                                    double Lon1, 
                                                    double Lat2, 
                                                    double Lon2)
            {
                try
                {
                    double _radLat1 = Lat1 * _toRad;
                    double _radLat2 = Lat2 * _toRad;
                    double _radLon1 = Lon1 * _toRad;
                    double _radLon2 = Lon2 * _toRad;
        
                    // central angle, aka arc segment angular distance
                    double _centralAngle = Math.Acos(Math.Sin(_radLat1) * Math.Sin(_radLat2) +
                            Math.Cos(_radLat1) * Math.Cos(_radLat2) * Math.Cos(_radLon2 - _radLon1));
        
                    // great-circle (orthodromic) distance on Earth between 2 points
                    return _radiusEarthMiles * _centralAngle;
                }
                catch { throw; }
            }
    
    // Great-circle distance calculation using Spherical Earth projection formula**
    
    /// <summary>
    /// Spherical Earth projection to a plane formula (using Pythagorean Theorem)
    /// to calculate great-circle (orthodromic) distance on Earth.
    /// http://en.wikipedia.org/wiki/Geographical_distance
    /// central angle = 
    /// Sqrt((_radLat2 - _radLat1)^2 + (Cos((_radLat1 + _radLat2)/2) * (Lon2 - Lon1))^2)
    /// Medium Accuracy, Fast,
    /// relative error less than 0.1% in search area smaller than 250 miles
    /// </summary>
    /// <param name="Lat1">double: 1st point Latitude</param>
    /// <param name="Lon1">double: 1st point Longitude</param>
    /// <param name="Lat2">double: 2nd point Latitude</param>
    /// <param name="Lon2">double: 2nd point Longitude</param>
    /// <returns>double: distance in miles</returns>
    public static double DistanceMilesSEP(double Lat1,
                                          double Lon1,
                                          double Lat2,
                                          double Lon2)
    {
        try
        {
            double _radLat1 = Lat1 * _toRad;
            double _radLat2 = Lat2 * _toRad;
            double _dLat = (_radLat2 - _radLat1);
            double _dLon = (Lon2 - Lon1) * _toRad;
    
            double _a = (_dLon) * Math.Cos((_radLat1 + _radLat2) / 2);
    
            // central angle, aka arc segment angular distance
            double _centralAngle = Math.Sqrt(_a * _a + _dLat * _dLat);
    
            // great-circle (orthodromic) distance on Earth between 2 points
            return _radiusEarthMiles * _centralAngle;
        }
        catch { throw; }
    }
