    public class Amount
    {
        [JsonProperty("value")]
        public decimal? Value { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }
