    public class CartViewModel
    {
        public ProductViewModel { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
