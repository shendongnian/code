    new Container(x => {
    
        x.Scan(a => {
            a.AssembliesFromApplicationBaseDirectory();
            a.WithDefaultConventions();
        });
    
        x.For<ISessionFactory>().Singleton().Use(...);
        x.For<ISession>().HybridHttpOrThreadLocalScoped().Use(sf => sf.GetInstance<ISessionFactory>().OpenSession());
        x.For<StringArrayType>().Use<StringArrayType>();
    
    });
