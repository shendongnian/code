    var factory = new DelegateFactory<IRepository>(() =>
    {
        return container.GetInstance<MyRepository>();
    });
    container.RegisterSingle<IFactory<IRepository>>(factory);
