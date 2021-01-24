    public static TGeographicCoordinate DestinationPointFromStartPoint(TGeographicCoordinate start, double distance = 1f, double bearing = 90f, double earthRadius = 6371.009d)
            {
                TGeographicCoordinate result = new TGeographicCoordinate();
                double angularDistanceRdn = distance / earthRadius;
                double bearingRad = Mathf.Deg2Rad * bearing;
    
                double startLatRad = start.Latitude * Mathf.Deg2Rad;
                double startLonRad = start.Longitude * Mathf.Deg2Rad;
    
                result.Latitude = Math.Asin((Math.Sin(startLatRad) * Math.Cos(angularDistanceRdn)) +
                          (Math.Cos(startLatRad) * Math.Sin(angularDistanceRdn) * Math.Cos(bearingRad)));
                result.Longitude = startLonRad + Math.Atan2(Math.Sin(bearingRad) * Math.Sin(angularDistanceRdn) * Math.Cos(startLatRad),
                                             Math.Cos(angularDistanceRdn) - (Math.Sin(startLatRad)) * Math.Sin(result.Latitude));
    
                result.Latitude *= Mathf.Rad2Deg;
                result.Longitude *= Mathf.Rad2Deg;
    
                return result;
            }
