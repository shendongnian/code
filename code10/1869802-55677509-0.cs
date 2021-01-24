    //Root class so you don't need to serialise an anonymous type and can easily deserialise later
    public class Root
    {
        public List<Document> Documents { get; set; }
    }
    
    public class Document
    {
        public string Index { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
    
        //This attribute controls the JSON property name
        [JsonProperty("@Timestamp")]
        public string Timestamp { get; set; }
    
    }
