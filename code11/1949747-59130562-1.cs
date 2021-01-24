    public class FiatPrices
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("data_fiat")]
        public Dictionary<string, decimal> Prices { get; set; }
    }
