    public class FavoriteProduct
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("lastUpdate")]
        public string LastUpdate { get; set; }
    }
