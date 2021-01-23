    ...
    //constructor
    public WindsorControllerFactory(ISessessionFactory) {
        Initialize();
        // Set the session Factory for NHibernate
        _container.Register(
        Component.For<ISessionFactory>()
                 .UsingFactoryMethod(
                      () => sessionFactory)
                      .LifeStyle
                      .Transient
                 );
    }
    private void Initialize() {
        _container = new WindsorContainer(
                         new XmlInterpreter(
                             new ConfigResource("castle")
                         )
                     );
        _container.AddFacility<FactorySupportFacility>();
        // Also register all the controller types as transient
        var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                          where typeof(IController).IsAssignableFrom(t)
                          select t;
        foreach (var t in controllerTypes) {
            _container.AddComponentLifeStyle(t.FullName, t, LifestyleType.Transient);
        }
    }
    ....
