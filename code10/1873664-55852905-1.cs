    [JsonConverter(typeof(ResultConverter))]
    public class Result
    {
        public string String { get; set; }
        public CodeMsg cm { get; set; }
    }
