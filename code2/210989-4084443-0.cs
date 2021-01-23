    public IEnumerable<Order> GetOrders(long CustomerID)
    {
       Repository<Order> orderRepository = new Repository<Order>(); // should use DI here, but i digress
       return orderRepository
                 .Find() // no query executed...
                 .Where(o => o.CustomerID == CustomerID) // still nothing...
                 .ToList(); // query executed, with BL applied! cool!
    }
