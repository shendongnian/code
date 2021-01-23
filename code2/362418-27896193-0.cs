    public class Customer
    {
        public int CustomerId { get; set; }
    }
    public class Order
    {
        public Customer Customer { get; set; }
        private int _customerId;
        private int CustomerId { get { return _customerId; } set { Customer.CustomerId = _customerId = value; } }
        public Order()
        {
            Customer = new Customer();
        }
    }
