    public class TestDTO
    {
        [JsonConverter(typeof(LongToStringConverter))]
        public IEnumerable<long> BigNumbers { get; set; }
    }
