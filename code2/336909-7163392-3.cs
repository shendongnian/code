    public static class UnitTestHelper
    {
        private static int _nextCustomerId = 0;
        private static int _nextOrderId = 0;
        public static Customer MockCustomer(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("name");
            var id = _nextCustomerId;
            _nextCustomerId += 1;
            return new Customer
                {
                    Id = id,
                    Name = name,
                    Orders = new List<Order>()
                };
        }
        public static Customer WithOrder(this Customer customer, int value)
        {
            if (customer == null) throw new ArgumentNullException("customer");
            var order = new Order
                {
                    Id = _nextOrderId,
                    Customer = customer.Id,
                    Value = value
                };
            customer.Orders.Add(order);
            _nextOrderId += 1;
            return customer;
        }
        public static Mock<Repository> HavingCustomers(this Mock<Repository> repository,
                                                       params Customer[] customers)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            var allOrders = customers.SelectMany(c => c.Orders);
            repository.Setup(r => r.Customers)
                      .Returns(new FakeObjectSet<Customer>(customers));
            repository.Setup(r => r.Orders)
                      .Returns(new FakeObjectSet<Order>(allOrders));
            return repository;
        }
    }
