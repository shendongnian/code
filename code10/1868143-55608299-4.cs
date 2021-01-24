    class Request
    {
        public Amount amount { get; set; }
        public AdditionalData additionalData { get; set; }
    }
    class Amount
    {
        public string currency { get; set; }
        public decimal value { get; set; }
    }
    class AdditionalData
    {
        [JsonProperty("payment.token")]
        public string applePayToken { get; set; }
    }
