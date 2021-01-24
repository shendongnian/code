    public class SomeClass
    {
        [JsonConverter(typeof(LocalDateTimeConverter))]
        public DateTime date { get; set; }
    }
