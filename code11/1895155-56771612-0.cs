        public class SignInName
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
    public class Value
    {
        [JsonProperty(PropertyName = "odata.type")]
        public string OdataType { get; set; }
        public string ObjectType { get; set; }
        public List<SignInName> SignInNames { get; set; }
        public string PersonId { get; set; }
    }
    public class YourClassName
    {
        [JsonProperty(PropertyName = "odata.metadata")]
        public string OdataMetadata { get; set; }
        [JsonProperty(PropertyName = "odata.nextLink")]
        public string OdataNextLink { get; set; }
        public List<Value> Value { get; set; }
    }
