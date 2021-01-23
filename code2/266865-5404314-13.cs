    public static void RegisterFactory<T>(
        this Container container,
        Func<T> instanceCreator)
    {
        var factory = new DelegateFactory<T>(instanceCreator);
        container.RegisterSingle<IFactory<T>>(factory);
    }
