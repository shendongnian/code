    var config = new Configuration()
                .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
                .DataBaseIntegration(d =>
                                         {
                                             d.ConnectionString = "foo";
                                             d.Dialect<SQLiteDialect>();
                                         });
