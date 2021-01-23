                container.Register<IDbConnectionFactory>(
                    c => {
                        OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["MyTransactionalDB"].ConnectionString, MySqlDialect.Provider);
                        dbFactory.ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current);
                        dbFactory.RegisterConnection("LoggingDB", ConfigurationManager.ConnectionStrings["MyLoggingDB"].ConnectionString, MySqlDialect.Provider);
                        return dbFactory;
                    });
