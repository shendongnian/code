    private static ISessionFactory CreateSessionFactory()
    {
      return Fluently.Configure()
        .Database(
          SQLiteConfiguration.Standard
            .UsingFile("firstProject.db")
        )
        .Mappings(m =>
          m.FluentMappings.AddFromAssemblyOf<Program>())
        .ExposeConfiguration(BuildSchema)
        .BuildSessionFactory();
    }
     
    private static void BuildSchema(Configuration config)
    {
      // delete the existing db on each run
      if (File.Exists(DbFile))
        File.Delete(DbFile);
     
      // this NHibernate tool takes a configuration (with mapping info in)
      // and exports a database schema from it
      new SchemaExport(config)
        .Create(false, true);
    }
