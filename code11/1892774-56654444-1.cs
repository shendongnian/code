    struct Result {
        public Result(Coordinate coordinate, double distance) {
             Coordinate = coordinate;
             Distance = distance;
        }
        public Coordinate Coordinate { get; }
        public double Distance { get; }
    }
