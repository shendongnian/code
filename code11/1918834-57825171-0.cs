    public class Data
    {
        [JsonProperty("data_positions")]
        public Dictionary<string, DataPosition> DataPositions { get; set; }
    }
    
    public class DataPosition
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("numberOfPos")]
        public int NumberOfPos { get; set; }
    
        [JsonProperty("partners")]
        public Dictionary<string, Partner> Partners { get; set; }
    }
    
    public class Partner
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("numberOfPos")]
        public int NumberOfPos { get; set; }
    }
