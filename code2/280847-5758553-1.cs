    public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                               .ConnectionString(c => c.FromConnectionStringWithKey("AppData")))
                               .Mappings(m => 
                               {
                                m.FluentMappings.Add(typeof(Domain.Mappings.UserMap));
                                m.FluentMappings.Add(typeof(Domain.Mappings.CloudFileMap));
                                m.FluentMappings.Add(typeof(Domain.Mappings.CompanyMap));
                                m.FluentMappings.Add(typeof(Domain.Mappings.UserRoleMap));
                               })
                               //.ExposeConfiguration(BuildSchema)
                               .BuildSessionFactory();
        }
