    public class Property
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public class Schema
    {
        [JsonProperty("rid")]
        public int Rid { get; set; }
        [JsonProperty("$esn")]
        public string Esn { get; set; }
        [JsonProperty("properties")]
        public IList<Property> Properties { get; set; }
    }
    public class Example
    {
        [JsonProperty("schema")]
        public Schema Schema { get; set; }
        [JsonProperty("$ts")]
        public DateTime Ts { get; set; }
        [JsonProperty("values")]
        public IList<object> Values { get; set; }
    }
