    public class RootObject
        {
            [JsonProperty(PropertyName ="name")]
            public string Apple { get; set; }
            public int age { get; set; }
            public List<string> cars { get; set; }
        }
