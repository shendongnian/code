    private static ISessionFactory BuildSessionFactory()
    {
        return Fluently
            .Configure()
            .Database(
                MsSqlConfiguration
                    .MsSql2005
                    .ConnectionString(c => c.FromConnectionStringWithKey("gwd"))
             )
             .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
             .ExposeConfiguration(config => new SchemaExport(config).Create(false, true))
             .BuildSessionFactory();
    }
