    class Products
    {
        public bool Contains(string term) {
                  return Name.Contains(search) | Size.Contains(search) | 
                  ProductId.Contains(search) | Category.Contains(search)
        }
        public string Name { get; set; }
        public string Size { get; set; }
        public string ProductId { get; set; }
        public string Category { get; set; }
    }
