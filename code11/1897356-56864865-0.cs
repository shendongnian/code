    public class OrderBook
    {
        [JsonProperty("lastUpdateId")]
        public int lastUpdateId { get; set; }
        [JsonProperty("bids")]
        public IList<IList<string>> Bids { get; set; }
        [JsonProperty("asks")]
        public IList<IList<string>> Asks { get; set; }
    }
