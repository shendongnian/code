    using (EntityConnection connection =  EntityConnection("name=AdventureWorksEntities"))
    {
    	AdventureWorksEntities context = new AdventureWorksEntities(connection);
    	context.AddObject("Customer", customer);
    	context.SaveChanges();
    }
