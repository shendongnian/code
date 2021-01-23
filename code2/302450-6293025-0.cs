    container.Register<IFoo>(new InjectionFactory(c =>
    {
        if (HttpContext.User.IsInRole("SUPERUSERS"))
            return container.Resolve<Foo1>();
        return container.Resolve<Foo2>();
    }));
