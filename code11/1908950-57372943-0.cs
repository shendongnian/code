    public class SensorConfiguration
    {
        [JsonProperty]
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SensorType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SensorLocation Location { get; set; }
    
        public SensorConfiguration()
        {
        }
    
        public SensorConfiguration(string name, SensorType type, SensorLocation location)
        {
            Name = name;
            Type = type;
            Location = location;
        }
    }
