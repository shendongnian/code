    public class Customer {
        private IList<Order> _orders;
        public Customer() {
            _orders = new List<Order>();
        }
        public IList<Order> Orders {
            get {
                return _orders;
            } 
        }
    }
