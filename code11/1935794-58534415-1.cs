    public class MyObject
    {
        [JsonProperty("Difficult")]
        public bool Difficult { get; set; }
        [JsonProperty("Impossible")]
        public bool Impossible { get; set; }
    }
    public class MyData {
        [JsonProperty("myObject")]
        public MyObject { get; set; }
    }
