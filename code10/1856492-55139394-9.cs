    var repositoryFactory = new RepositoryFactory() {AccessRights = ...}
    // I need to query only:
    using (var repository = repositoryFactory.CreateUpdatAccess())
    {
         // you can query, change value and save changes, for instance after a Brexit:
         var customersToRemove = repository.Customers.Where(customer => customer.State == "United Kingdom")
         foreach (var customerToRemove in customersToRemove);
         {
             customerToRemove.MarkObsolete();
         }
         repository.SaveChanges();
    }
    // I need to change data:
    using (var repository = repositoryFactory.CreateReadOnly())
    {
         // do some queries. Compiler error if you try to change
    }
