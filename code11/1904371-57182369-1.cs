    static void Main(string[] args)
    {
        var data = new[]
        {
            new {CustomerId = 1, OrderId = 123, Product = "Apple"},
            new {CustomerId = 1, OrderId = 123, Product = "Pear"},
            new {CustomerId = 1, OrderId = 124, Product = "Apple"},
        };
        var result = data.GroupBy(co => co.CustomerId)
            .Select(co => new CustomerOrders
            {
                CustomerID = co.Key,
                OrderID = co.GroupBy(oi => oi.OrderId)
                    .Select(oi => new OrderIDs
                    {
                        OrderID = oi.Key,
                        Product = oi.Select(p => p.Product).ToList()
                    }).OrderBy(oi => oi.OrderID).ToList()
            }).ToList();
    }
    class CustomerOrders
    {
        public int CustomerID { get; set; }
        public IEnumerable<OrderIDs> OrderID;
    }
    class OrderIDs
    {
        public int OrderID { get; set; }
        public IEnumerable<string> Product { get; set; }
    }
