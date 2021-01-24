     public class Order     {
                public long Id { get; set; }
                public long CustomerId { get; set; }
                public DateTime OrderDateTime { get; set; }
                public virtual ICollection<OrderItem> OrderItems { get; set; }
          }
    public class OrderItem
   
    {  
        [Key]
        public int OrderItemId { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }
        public long OrderId{get;set;} // ForeignKey OrderId
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    
    }
