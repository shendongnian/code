    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        private List<OrderItem> _orderItems;
        public List<OrderItem> OrderItems
        {
            get { return _orderItems; }
            set
            {
                _orderItems = value;
                if (_orderItems == null)
                    _orderItems = new List<OrderItem>();
                while (_orderItems.Count < 6)
                    _orderItems.Add(new OrderItem());
            }
        }
        public Order()
        {
            // invoke the setter logic on object creation
            this.OrderItems = null;
        }
    }
