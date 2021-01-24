    public class ProductType
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
    public class ArrayOfProductType
    {
        [JsonProperty(PropertyName = "@xmlns:i")]
        public string xmlnsi { get; set; }
        [JsonProperty(PropertyName = "@xmlns")]
        public string xmlns { get; set; }
        public List<ProductType> ProductType { get; set; }
    }
    public class RootObject
    {
        public ArrayOfProductType ArrayOfProductType { get; set; }
    }
