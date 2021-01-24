    public MyDBContext(string nameOrConnectionString)
        : base(nameOrConnectionString)
    {
        this.Configuration.LazyLoadingEnabled = false;
        this.Configuration.ProxyCreationEnabled = false;
        this.Database.CommandTimeout = 60;
        IDatabaseInitializerCreator creator = new DatabaseInitializerCreator();
        Database.SetInitializer(creator.Create());
    }
