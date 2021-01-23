    Fluently.Configure()
    	.Database(MySqlConfiguration.Standard
    		.ConnectionString(x => x.FromConnectionStringWithKey("Test"))
    		.AdoNetBatchSize(50))
    	.Cache(c => c
    		.UseQueryCache()
    		.ProviderClass<HashtableCacheProvider>())
    	.Mappings(m =>
    	{
    		m.FluentMappings.AddFromAssemblyOf<IHaveFluentNHibernateMappings>().Conventions.Add(ForeignKey.EndsWith("Id"));
    		m.HbmMappings.AddFromAssemblyOf<IHaveFluentNHibernateMappings>();
    	})
    	.BuildConfiguration();
