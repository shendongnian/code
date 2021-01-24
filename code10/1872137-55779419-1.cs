    public class OrderStatus 
    {
       [Key]
       public long orderStatusId { get; set; }
       public string string code { get; set; }
       public string description { get; set; }
       public int severityLevel { get; set; }
       ...........
    
       public List<Order> Orders { get; set; }
    }
    
    public class Order 
    {
        [Key]
        public long orderId { get; set; }
        
        [ForeignKey("OrderStatus")]
        public OrderStatus orderStatusId { get; set; }
        ..........
    
        public OrderStatus OrderStatus { get; set; }
    }
