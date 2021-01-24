    public class OrderBook
    {
        [JsonProperty("lastUpdateId")]
        public int lastUpdateId { get; set; }
        [JsonProperty("bids")]
        public List<List<string>> bids { get; set; }
        [JsonProperty("asks")]
        public List<List<string>> asks { get; set; }
    }
