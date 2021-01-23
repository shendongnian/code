    public ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008
                           .ConnectionString(c => c.FromConnectionStringWithKey("AppData")))
                           .Mappings(m => 
                           {
                            m.FluentMappings.AddFromAssemblyOf<UserMap>()
                           })
                           //.ExposeConfiguration(BuildSchema)
                           .BuildSessionFactory();
    }
