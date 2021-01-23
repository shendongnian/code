    var cfg = new Configuration();
    // set connectionstring programmatically
    cfg.Properties["connection.connection_string"] = getConnectionString(sitename);
    cfg.Configure();
    
    cfg.AddAssembly( ... );
    ISessionFactory sf = cfg.BuildSessionFactory();
