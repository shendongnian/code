    private void CreateSessionFactory()
        {
            _sessionFactory = Fluently
                    .Configure()
                    .Database((MsSqlConfiguration.MsSql2008 // 
                            .ConnectionString(c=>c.FromConnectionStringWithKey("abc"))
                            .ShowSql()))
                    .CurrentSessionContext("web")
                    .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<UserMap>())
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                    .BuildSessionFactory();
        }
