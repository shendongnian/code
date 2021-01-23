	return Fluently.Configure()
		.ProxyFactoryFactory(typeof(ProxyFactoryFactory))
		.Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString)
			.Mappings(m =>
			{
				m.FluentMappings.AddFromAssemblyOf<Entities.BaseEntity>();
				m.FluentMappings.Conventions.AddFromAssemblyOf<Entities.BaseEntity>();
			})
			.ExposeConfiguration((cfg => BuildDatabase(cfg)))
			.BuildSessionFactory();
	private static void BuildDatabase(Configuration cfg, IDatabaseConfiguration configurationManager)
	{
		cfg.AddXmlFile(@"Mappings\Hbm\Indexes.hbm.xml");
		new SchemaExport(cfg).SetOutputFile(SchemaOutputFileName).Create(false, false);
	}
