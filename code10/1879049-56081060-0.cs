    public class Products
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonProperty(PropertyName = "price")]
        public string pricePerUnit { get; set; }
    }
