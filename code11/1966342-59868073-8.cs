    class SomeModel
    {
        public string Title { get; set; }
        [JsonConverter(typeof(NestedPropertyConverter), "id")]
        [JsonProperty("supplier")] //its necessary to specify top level property name
        public int SupplierId { get; set; }
        [JsonProperty("count")]
        public double Amount { get; set; }
    }
