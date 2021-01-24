    public class MyPoint : Point
    {
        [JsonConstructor]
        public MyPoint(double latitude, double longitude, int srid)
            :base(new GeoAPI.Geometries.Coordinate(longitude, latitude))
        {
            SRID = srid;
        }
    }
