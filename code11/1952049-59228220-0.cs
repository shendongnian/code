    public class Aa
        {
            [JsonProperty("colorImages")]
            public Dictionary<string, List<ImageItem>> Images { get; set; }
        }
        public class ImageItem
        {
            [JsonProperty("large")]
            public Uri Large { get; set; }
    
            [JsonProperty("thumb")]
            public Uri Thumb { get; set; }
    
            [JsonProperty("hiRes")]
            public Uri HiRes { get; set; }
    
            [JsonProperty("variant")]
            public string Variant { get; set; }
    
            [JsonProperty("main")]
            public Dictionary<string, List<long>> Main { get; set; }
        }
