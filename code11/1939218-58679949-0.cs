    public class ISS
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "latitude")]
        public double latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double longitude { get; set; }
        [JsonProperty(PropertyName = "altitude")]
        public double altitude { get; set; }
        [JsonProperty(PropertyName = "velocity")]
        public double velocity { get; set; }
        [JsonProperty(PropertyName = "visibility")]
        public string visibility { get; set; }
        [JsonProperty(PropertyName = "footprint")]
        public double footprint { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public int timestamp { get; set; }
        [JsonProperty(PropertyName = "daynum")]
        public double daynum { get; set; }
        [JsonProperty(PropertyName = "solar_lat")]
        public double solar_lat { get; set; }
        [JsonProperty(PropertyName = "solar_lon")]
        public double solar_lon { get; set; }
        [JsonProperty(PropertyName = "units")]
        public string units { get; set; }
    }
