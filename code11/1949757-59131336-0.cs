        public Videos videos { get; set; }
        public Results results { get; set; }
    }
    public class Videos
    {
        public object[] results { get; set; }
    }
    class Results
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("iso_639_1")]
        public string ISO6391 { get; set; }
        [JsonProperty("iso_3166_1")]
        public string ISO31661 { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("site")]
        public string Site { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
       
    }
