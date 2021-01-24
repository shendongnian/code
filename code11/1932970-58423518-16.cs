    public class PointOfInterest : ICoordinate {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    
        public PointOfInterest(double plat, double plong) {
            Latitude = plat;
            Longitude = plong;
        }
        public ICoordinate MakeNew(double plat, double plong) => new PointOfInterest(plat, plong);
    }
