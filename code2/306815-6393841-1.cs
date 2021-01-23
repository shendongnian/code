    var fluent = Fluently.Configure()
        .Mappings(c => c.AutoMappings.Add(AutoMap.AssemblyOf<Units>()
            .Override<Units>(u => u.Id(uu => uu.Unit_Id).GeneratedBy.Native())))
        .Database(() => SQLiteConfiguration.Standard.UsingFile("test.sqlite3"));
    var configuration = fluent.BuildConfiguration();
    // Generate database schema
    new SchemaExport(configuration).Create(false, true);
    var sessionFactory = configuration.BuildSessionFactory();
    // Now just open session and do whatever you need
