    const string Name = "Foo";
    // Singleton Binding. Will only be used when the context uses the {Name}
    Bind<Foo>().To<Foo>()
        .Named(Name)
        .InSingletonScope();
    // Unnamed binding with method call on each resolution
    Bind<Foo>().ToMethod(ctx => 
        {
            // Do anything arbitrary here. like calling a method...
            return ctx.Kernel.Get<Foo>(Name));
        });
