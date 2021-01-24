    public class CreateSummaryModel
    {
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("productName")]
        public List<string> ProductName { get; set; }
    }
    public class Address
    {
        [JsonProperty("city")]
        public string City { get; set; }
    }
