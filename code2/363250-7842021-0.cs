    var cfg = new NHibernate.Cfg.Configuration();
    cfg.Configure(); // read config default style
    Fluently.Configure(cfg)
        .Mappings(
          m => m.FluentMappings.AddFromAssemblyOf<Entity>())
        .BuildSessionFactory();
