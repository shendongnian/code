    public class OrderStatusWrapper
    {
        private OrderStatus _status;
        public int Value
        {
            get { return (int)_status; }
            set { _status = (OrderStatus)value; }
        }
        public OrderStatus EnumValue
        {
            get { return _status; }
            set { _status = value; }
        }
        public static implicit operator
             OrderStatusWrapper(OrderStatus status)
        {
            return new OrderStatusWrapper { EnumValue = status };
        }
        public static implicit operator
            OrderStatus(OrderStatusWrapper statusWrapper)
       {
           if (statusWrapper == null) return OrderStatus.OrderCreated;
           else return statusWrapper.EnumValue;
       }
    }
