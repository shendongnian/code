    public class ProductEntity
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public string PricePerUnit { get; set; }
    }
