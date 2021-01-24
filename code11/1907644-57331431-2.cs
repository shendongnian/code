        var dbSessionFatory = Fluently
                            .Configure()
                            .Database(() =>
                            {
                                return FluentNHibernate.Cfg.Db.MsSqlConfiguration
                                        .MsSql2008
                                        .ShowSql()
                                        .ConnectionString(Configuration.GetConnectionString("DbConnectionString"));
                            })
                            .BuildSessionFactory();
        var adminDbSessionFactory= Fluently
                            .Configure()
                            .Database(() =>
                            {
                                return FluentNHibernate.Cfg.Db.MsSqlConfiguration
                                        .MsSql2008
                                        .ShowSql()
                                        .ConnectionString(Configuration.GetConnectionString("AdminDbConnectionString"));
                            })
                            .BuildSessionFactory();
           services.AddSingleton<NHibernate.ISession>(factory => dbSessionFatory.OpenSession());
           services.AddSingleton<NHibernate.ISession>(factory => adminDbSessionFactory.OpenSession());
    
