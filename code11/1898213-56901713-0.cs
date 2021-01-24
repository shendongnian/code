    public class CartViewModel
    {
        public List<CartItemModel> CartItemList { get; set; }
        public decimal NetTotal { get; set; }
        public CartViewModel()
        {
            CartItemList = new List<CartItemModel>();
        }
    }
    public class CartItemModel
    {
        public long CartId { get; set; }
        public long ProductId { get; set; } 
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string VariantName { get; set; }
        public string VariantGroup { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPromotional { get; set; }
    }
