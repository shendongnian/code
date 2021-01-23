    protected override void Configure()
    {
        container = new SimpleContainer();
        container.RegisterSingleton(typeof(MainViewModel), null, typeof(MainViewModel));
        container.RegisterSingleton(typeof(IWindowManager), null, typeof(WindowManager));
    }
    protected override object GetInstance(Type service, string key)
    {
        return container.GetInstance(service, key);
    }
