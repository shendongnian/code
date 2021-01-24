    public class OrdersManager 
    {
        public OrdersManager()
        {
            OrdersById = new ConcurrentDictionary<string, Order>();
        }
        private ConcurrentDictionary<string, Order> OrdersById { get; }
        public void AddOrder()
        {
            OrdersById.TryAdd(...);
        }
        ... All others usefull methods
    }
