    container.Register<IPrincipal>(
        new InjectionFactory(c => HttpContext.User));
    container.Register<IFoo>(new InjectionFactory(c =>
    {
        return new UserBasedFoo(container.Resolve<IPrincipal>(),
            container.Resolve<Foo1>(),
            container.Resolve<Foo2>());
    }));
