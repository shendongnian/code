    public MyAppContext() : base("name=MyConnectionString") //-> change ctor like this
    {
        Database.SetInitializer<MyAppContext>(new CreateDatabaseIfNotExists<MyAppContext>());
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyAppContext, Project.Migrations.Configuration>("MyConnectionString"));
    }
