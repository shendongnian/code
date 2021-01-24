        public partial class ProductClass
        {
            [JsonProperty("products")]
            public Products Products { get; set; }
        }
        public partial class Products
        {
            [JsonProperty("prd")]
            public List<Prd> Prd { get; set; }
            [JsonProperty("user key")]
            public string UserKey { get; set; }
            [JsonProperty("post date")]
            public DateTimeOffset PostDate { get; set; }
        }
        public partial class Prd
        {
            [JsonProperty("pinno")]
            public string Pinno { get; set; }
            [JsonProperty("expirydate")]
            public DateTimeOffset Expirydate { get; set; }
            [JsonProperty("remark")]
            public string Remark { get; set; }
        }
