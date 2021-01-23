    private static IUnityContainer _container = new ContainerImpl();
    public static IUnityContainer Container
    {
        get
        {
            return _container;
        }
        set
        {
            _container = value ?? _container;
        }
    }
