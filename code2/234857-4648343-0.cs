    public MyService(Func<IDependency> dependencyProvider)
    {
        this.dependencyProvider = dependencyProvider;
    }
    public Message Method1()
    {
        IDependency dependency = dependencyProvider();
        dependency.DoSomething();    
    }
