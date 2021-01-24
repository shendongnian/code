    class Document
    {
        [JsonProperty(PropertyName = "filename")]
        public string Filename { get; set; }
    
        [JsonProperty(PropertyName = "sourceProperties")]
        public SourceProperties Source { get; set; }
    }
    
    class SourceProperties
    {
        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, string> Properties { get; set; }
    }
