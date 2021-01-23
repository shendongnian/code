    private static ISessionFactory BuildSessionFactory()
            {
                AutoPersistenceModel model = CreateMappings();
    
                return Fluently.Configure().Database(MsSqlConfiguration.MsSql2005
      .ConnectionString(c => c.FromConnectionStringWithKey("gwd"))).Mappings(m => m.AutoMappings.Add(model))
        .ExposeConfiguration((Configuration config) => new SchemaExport(config).Create(false, true)).BuildSessionFactory();
    
            }
