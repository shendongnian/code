    public class Attachment
    {
        [JsonProperty("@odata.type")]
        public string OdataType { get; set; }
        
        public string Name { get; set; }
        
        public string ContentBytes { get; set; }
    }
