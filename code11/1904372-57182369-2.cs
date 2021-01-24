    static void Main(string[] args)
    {
        var data = new[]
        {
            new DbRow { CustomerId = 1, OrderId = 123, Product = "Apple" },
            new DbRow { CustomerId = 1, OrderId = 123, Product = "Pear" },
            new DbRow { CustomerId = 1, OrderId = 124, Product = "Apple" }
        };
        var resultFullLinq = data.GroupBy(row => row.CustomerId)
            .Select(groupCustomer => new CustomerOrder
            {
                Id = groupCustomer.Key,
                Orders = groupCustomer.GroupBy(row => row.OrderId)
                    .Select(groupOrder => new Order
                    {
                        Id = groupOrder.Key,
                        Products = groupOrder.Select(row => row.Product).ToList()
                    }).OrderBy(order => order.Id).ToList()
            }).ToList();
        // OR use methods
        var resultMethods = data.GroupBy(row => row.CustomerId).Select(groupCustomer => CreateCustomerOrder(groupCustomer)).ToList();
    }
    private static CustomerOrder CreateCustomerOrder(IGrouping<int, DbRow> groupCustomer)
    {
        return new CustomerOrder
        {
            Id = groupCustomer.Key,
            Orders = GetOrderIds(groupCustomer).OrderBy(order => order.Id).ToList()
        };
    }
    private static IEnumerable<Order> GetOrderIds(IGrouping<int, DbRow> groupCustomer)
    {
        return groupCustomer.GroupBy(row => row.OrderId).Select(groupOrder => GetOrderId(groupOrder));
    }
    private static Order GetOrderId(IGrouping<int, DbRow> groupOrder)
    {
        return new Order
        {
            Id = groupOrder.Key,
            Products = groupOrder.Select(p => p.Product)
        };
    }
    
    // Class that represent a row of the database
    public class DbRow
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Product { get; set; }
    }
    class CustomerOrder
    {
        public int Id { get; set; }
        public IEnumerable<Order> Orders;
    }
    class Order
    {
        public int Id { get; set; }
        public IEnumerable<string> Products { get; set; }
    }
