    public class Keys
    {
        [JsonProperty(PropertyName = "RegistrationKey")]
        public string RegistrationKey { get; set; }
        [JsonProperty(PropertyName = "ValidationStatus")]
        public string ValidationStatus { get; set; }
        [JsonProperty(PropertyName = "ValidationDescription")]
        public string ValidationDescription { get; set; }
        [JsonProperty(PropertyName = "Properties")]
        public List<Properties> PropertiesList { get; set; }
    }
    public class Properties
    {
        [JsonProperty(PropertyName = "Key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }
    }
