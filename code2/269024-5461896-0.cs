    _sessionFactory = Fluently.Configure()
        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("DB")))
        .Mappings(
            m =>
            m.AutoMappings.Add(AutoMap.AssemblyOf<Customer>(new AutomapConfiguration()).Conventions.
                                   Setup(c =>
                                             {
                                                 c.Add<PrimaryKeyConvention>();
                                                 c.Add<EnumConvention>();
                                                 c.Add<CascadeAllConvention>();
                                             })
                                   .IgnoreBase(typeof (EntityBase<>))
                                   .OverrideAll(map => map.IgnoreProperty("IsValid"))))
        .BuildSessionFactory();
