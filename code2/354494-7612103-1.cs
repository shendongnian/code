    class OrderFactory : IOrderFactory
    {
        public OrderFactory ( IProduct product );
        public Order GetOrder (count)
        {
            return new Order ( product, count );
        }
    }
