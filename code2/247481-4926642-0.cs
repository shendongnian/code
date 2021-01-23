    using (OrderDatabase ctx = new OrderDatabase())
    {
        ctx.AddOrder(new Order()
        {
            OrderQuantity = 2,
            OrderDescription = "Widgets",
            Customer = ctx.Customers.First<Customer>(c => c.CustomerId == yourId)
        });
        ctx.SaveChanges();
    }
