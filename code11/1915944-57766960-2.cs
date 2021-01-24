    private static Container container;
    public static Container Container
    {
        get { return container ?? (container = RegisterAndVerifyContainer()); }
    }
    private static Container RegisterAndVerifyContainer()
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        container.Register<IDBContext, MyDBContext>(Lifestyle.Singleton);
        container.Verify();
        return container;
    }
