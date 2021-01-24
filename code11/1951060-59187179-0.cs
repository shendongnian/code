    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
    public class OrderItem
    {
        public int OrderItemId { get; set; }//you need to define a primary key for OrderItem model
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }
        public Order Order { get; set; }
    }
