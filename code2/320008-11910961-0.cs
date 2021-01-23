    using (var container = ObjectFactory.Container.GetNestedContainer())
    {
        container.Configure(config => {
            config.For<ISiteContext>().Use<DummyContext>();
        });
        return container.GetInstance<TestMessageHandler>();
    }
