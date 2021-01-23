        public class Outer
        {
            [JsonProperty(PropertyName = "id")]
            public String Id { get; internal set; }
            [JsonProperty(PropertyName = "name")]
            public String Name { get; internal set; }
            [JsonProperty(PropertyName = "properties")]
            public Dictionary<String, String> Properties { get; internal set; }
            [JsonProperty(PropertyName = "inner_object")]
            public Newtonsoft.Json.Linq.JObject InnerObjectId { get; set; }
        }
