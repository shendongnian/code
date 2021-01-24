    using (var context = new EntityContext())
    {
        var customer = new Customer() {CustomerID = 1};
        context.Customers.Attach(customer);
        var entity = context.Entry(customer);
        Console.WriteLine(entity.State);
    }
