    public class MyElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("order")]
        public long Order { get; set; }
    
        [JsonProperty("type")]
        public string Type { get; set; }
    
        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
