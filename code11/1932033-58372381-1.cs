    public class Location
    {
        public string Name { get; set; }
    
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double Latitude { get; set; }
    
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double Longitude { get; set; }
    }
