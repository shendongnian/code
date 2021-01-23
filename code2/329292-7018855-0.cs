    Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());         
    using (var myContext = MyDbContext.GetContext("connectionString") 
    {           
        context.Database.Initialize(force: true);      
    } 
