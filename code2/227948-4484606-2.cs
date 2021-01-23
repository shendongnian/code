    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CreatedOn { get; set; }               
        public OrderStatusWrapper Status { get; set; }
    }    
    [ComplexType]
    public class OrderStatusWrapper 
    {
        private OrderStatus _status;
        [Column(Name="Status")]
        public int Value {
            get { return (int)_status; }
            set { _status = (OrderStatus)value; }
        }
        public OrderStatus EnumValue {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum OrderStatus
    {
        OrderCreated,
        OrderPayed,
        OrderShipped
    }
