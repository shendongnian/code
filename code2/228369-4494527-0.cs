    public void UpdateOrder(Order o)
    {
       var stub = new Order { Id = o.OrderId }; // create stub with EntityKey
       ctx.Orders.Attach(stub); // attach stub to graph
       ctx.ApplyCurrentValues("Orders", o); // override stub with values.
       ctx.SaveChanges();
    }
