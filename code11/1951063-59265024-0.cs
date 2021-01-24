    public class Order 
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
    
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
    
    public class OrderItem 
    {
        public long Id { get; set; }    
       
        [ForeignKey(nameof(OrderId)]
        public virtual Order Order { get; set; }
        public long OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }
    }
