    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CreatedOn { get; set; }
               
        public OrderStatusWrapper Status { get; set; }
    }    
    public class OrderStatusWrapper
    {
        private OrderStatus _status;
        public int Value
        {
            get
            {
                return (int)_status;
            }
            set
            {
                _status = (OrderStatus)value;
            }
        }
        public OrderStatus EnumValue
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }
     public enum OrderStatus
     {
         OrderCreated,
         OrderPayed,
         OrderShipped
     }
