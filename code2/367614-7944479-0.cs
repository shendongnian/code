    using (IKernel kernel = new StandardKernel())
    {
        kernel.Load("*.dll");
        var someClass = kernel.Get<SomeClassWithDependency>();
        someClass.TryDoSomething();
    }
