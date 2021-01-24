    public class SalesOrder :Order
    {
    }
    
    public class SalesOrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public SalesOrder Order { get; set; }
    }
