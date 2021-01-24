     public double distance(double lat1, double lon1, double lat2, double lon2, char unit)
            {
                if ((lat1 == lat2) && (lon1 == lon2))
                {
                    return 0;
                }
                else
                {
                    double theta = lon1 - lon2;
                    double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                    dist = Math.Acos(dist);
                    dist = rad2deg(dist);
                    dist = dist * 60 * 1.1515;
                    if (unit == 'K')
                    {
                        dist = dist * 1.609344;
                    }
                    else if (unit == 'N')
                    {
                        dist = dist * 0.8684;
                    }
                    return (dist);
                }
            }
            private static double deg2rad(double deg)
            {
                return (deg * Math.PI / 180.0);
            }
    
            private static double rad2deg(double rad)
            {
                return (rad / Math.PI * 180.0);
            }
