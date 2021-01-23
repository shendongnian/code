    public static void Initialise(string connStr)
		{
			_Factory = Fluently.Configure().Database(
					MsSqlConfiguration.MsSql2005
					.ConnectionString(connStr))
					.Mappings(m => m.FluentMappings.AddFromAssemblyOf<SessionHandler>())
					.ExposeConfiguration(cfg =>
					{
                        // This will set the command_timeout property on factory-level
                        cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "180");
                        // This will set the command_timeout property on system-level
                        NHibernate.Cfg.Environment.Properties.Add(NHibernate.Cfg.Environment.CommandTimeout, "180");
					})
					.BuildSessionFactory();
		}
