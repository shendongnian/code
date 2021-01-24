    class SomeModel
    {
        public string Title { get; set; }
        [JsonProperty("count")]
        public double Amount { get; set; }
        public int SupplierId => Supplier.Id;
        public Supplier Supplier { get; set; }
    }
    class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
