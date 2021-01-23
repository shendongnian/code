    private class WebService
    {
        public T GetOrders<T>(int customerId)
        {
            if (typeof(T) == typeof(List<Order>))
            {
                return new List<Order>();
            }
            if (typeof(T) == typeof(string))
            {
                return "42";
            }
        }
    }
