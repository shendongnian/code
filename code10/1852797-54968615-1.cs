    [Serializable]
    public class Table
    { 
        [JsonProperty("data")]
        [JsonConverter(typeof(DataConverter))]
        public Dictionary<string, string> Data { get; set; } 
    }
    [Serializable]
    public class Content
    { 
        [JsonProperty("table")]
        public Table[] Tables { get; set; }
    }
    [Serializable]
    public class MyObject
    {
        [JsonProperty("content")]
        public Content Content { get; set; }
    }
