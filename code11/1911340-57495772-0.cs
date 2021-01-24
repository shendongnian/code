    public class Example
    {
        [JsonExtensionData]
        public JObject First { get; set; }
    
        [JsonProperty(Order = 2)]
        public string Second { get; set; }
    }
