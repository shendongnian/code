    public class Model
    {
        [JsonConverter(typeof(ConcreteTypeConverter<Something>))]
        public ISomething TheThing { get; set; }
    }
