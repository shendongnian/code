    public class MyObject
    {
        [JsonPropertyAttribute("some_object")]
        [JsonConverter(typeof(EmptyArrayToObjectConverter<SomeObject>))]
        public SomeObject SomeObject { get; set; }
        ...
    }
