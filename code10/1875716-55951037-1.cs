    public class Location
    {
        [BsonElement("type")]
        public string Type { get; } = "Point";
        [BsonElement("coordinates")]
        public double[] Coordinates { get; set; } = new double[2] { 0.0, 0.0 };
        public double Latitude
        {
            get => Coordinates[1];
            set => Coordinates[1] = value;
        }
        public double Longitude
        {
            get => Coordinates[0];
            set => Coordinates[0] = value;
        }
    }
