    public static TGeographicCoordinate DestinationPointFromStartPoint(TGeographicCoordinate start, double distance = 100f, double bearing = 90f, double earthRadius = 6371.009d)
            {
                TGeographicCoordinate result = new TGeographicCoordinate();
                double angularDistanceRdn = Mathf.Deg2Rad * (distance / earthRadius);
                //double angularDistanceRdn = distance / earthRadius;
    
                result.Latitude = Math.Asin(Math.Sin(start.Latitude) * Math.Cos(angularDistanceRdn) +
                          Math.Cos(start.Latitude) * Math.Sin(angularDistanceRdn) * Math.Cos(bearing));
                result.Longitude = start.Longitude + Math.Atan2(Math.Sin(bearing) * Math.Sin(angularDistanceRdn) * Math.Cos(start.Latitude),
                                             Math.Cos(angularDistanceRdn) - Math.Sin(start.Latitude) * Math.Sin(result.Latitude));
    
                return result;
            }
