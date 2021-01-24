    public class MyObject
    {
        [JsonProperty("some_object")]
        [JsonConverter(typeof(ArrayToObjectConverter<SomeObject>))]
        public SomeObject SomeObject { get; set; }
    }
