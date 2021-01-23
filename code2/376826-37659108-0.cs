    container.RegisterType<ILoader, FooLoader>("foo");
    container.RegisterType<ILoader, BarLoader>("bar");
    container.RegisterType<ILoader, BazLoader>("baz");
    container.RegisterType<ILoader, BooLoader>("boo");
    container.RegisterType<IConsumer, MyConsumer>("c1",
        new InjectionConstructor(
            new ResolvedArrayParameter<ILoader>(
                new ResolvedParameter<ILoader>("foo"),
                new ResolvedParameter<ILoader>("bar"))));
    container.RegisterType<IConsumer, MyConsumer>("c2",
        new InjectionConstructor(
            new ResolvedArrayParameter<ILoader>(
                new ResolvedParameter<ILoader>("baz"),
                new ResolvedParameter<ILoader>("boo"))));
    var c1 = container.Resolve<MyConsumer>("c1");
    var c1 = container.Resolve<MyConsumer>("c2");
