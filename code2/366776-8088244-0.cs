    var cfg = new Configuration();
    
    var filterDef = new FilterDefinition(
        "filterName",
        null, // or your default condition
        new Dictionary<string, IType> { { "filterParamName", NHibernateUtil.Int32 } },
        false);
    cfg.AddFilterDefinition(filterDef);
    
    // cfg.AddMapping(...)
    // cfg.DataBaseIntegration(...)
    
    var sessionFactory = cfg.BuildSessionFactory();
