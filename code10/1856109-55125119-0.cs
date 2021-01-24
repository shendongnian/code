    // interface 
    interface IContext {
        T Get<T>(String name); 
        void Set<T>(String name, T value); 
    }
    // registration 
    builder.RegisterType<FooContext>().As<IContext>();
    builder.Register<IFoo>(c =>
    {
        var score = c.Resolve<IContext>().Get<Int32>("score"); 
        if (score >= 100)
        {
            return new HappyFoo();
        }
        return new SadFoo();
    });
    // usage 
    using (ILifetimeScope scope = container.BeginLifetimeScope())
    {
        scope.Resolve<IContext>().Set("score", 90); 
        scope.Resolve<IFooUser>().useFoo();
    }
