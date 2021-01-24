    class Order
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public static List<Order> Seed()
        {
            return new List<Order>
            {
                new Order { CustomerId = 1, OrderId = 1},
                new Order { CustomerId = 1, OrderId = 2},
                new Order { CustomerId = 1, OrderId = 3},
                new Order { CustomerId = 1, OrderId = 4},
                new Order { CustomerId = 1, OrderId = 5},
                new Order { CustomerId = 2, OrderId = 1},
                new Order { CustomerId = 2, OrderId = 2},
                new Order { CustomerId = 2, OrderId = 3},
                new Order { CustomerId = 2, OrderId = 4},
                new Order { CustomerId = 2, OrderId = 5},
                new Order { CustomerId = 2, OrderId = 6},
                new Order { CustomerId = 3, OrderId = 2},
                new Order { CustomerId = 3, OrderId = 3},
                new Order { CustomerId = 3, OrderId = 4}
            };
        }
    }
