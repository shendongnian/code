    private static ISessionFactory SessionFactory(System.Reflection.Assembly assembly)
    {
        if (_sessionFactory == null)
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(assembly);
            _sessionFactory = configuration.Configure().BuildSessionFactory();
        }
        return _sessionFactory;
    }
