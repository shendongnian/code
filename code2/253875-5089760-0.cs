    Customer customer = null;
    using (var context = new MyContext("ProductionConnectionString"))
    {
      // You must use Include to load all related data
      customer = context.Customers.Include("...").Where(...).Single();
    }
    
    using (var context= new MyContext("TestConnectionString"))
    {
      context.Customers.AddObject(customer); // Inserts everything
      using (var scope = new TransactionScope())
      {
        context.SaveChanges();
        scope.Complete();
      }
    }
