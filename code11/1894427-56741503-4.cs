    public class FavoriteProduct
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set; }
    }
