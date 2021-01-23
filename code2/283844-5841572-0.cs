    sessionFactory = Fluently.Configure(normalConfig)
                  .Mappings(m =>
                      m.FluentMappings
                      .AddFromAssemblyOf<OrderHeaderMap>()
                      .AddFromAssemblyOf<OrderLineMap>()
                      .Conventions.AddFromAssemblyOf<PascalCaseColumnNameConvention>())
                   .ProxyFactoryFactory("NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu")
                  .BuildSessionFactory();
