    public class MyObject
    {
        [JsonPropertyAttribute("some_object")]
        [JsonConverter(typeof(ArrayToObjectConverter<SomeObject>))]
        public SomeObject SomeObject { get; set; }
        ...
    }
