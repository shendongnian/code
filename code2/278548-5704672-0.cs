    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
    
    public calss ProductOrder
    {
        [Key]
        public int OrderProductId { get; set; }
        public int OrderStatus { get; set; }
        public virtual Product { get; set; }
        public virtual Order { get; set; }
    }
    
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public virtual Price Price { get; set;}
    }
    
    public class Price
    {
        [Key]
        public int PriceId { get; set;}
    }
