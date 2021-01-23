    public class BusinessList 
    {
        [JsonProperty(PropertyName = "Number")]
        public long Number{ get; set; }
        [JsonProperty(PropertyName = "BusinessUnitCode ")]
        public string BusinessUnitCode { get; set; }
        [JsonProperty(PropertyName = "Codes ")]
        public List<Codes> Codes { get; set; }
    }
    public class Codes
    {
        public string Code { get; set; }
    }
