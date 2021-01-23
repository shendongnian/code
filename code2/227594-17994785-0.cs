    public class ProductLine
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        // The level property is no longer needed because it is a property of the Node class
        public IEnumerable<ProductLine> Children { get; set; }
    }
