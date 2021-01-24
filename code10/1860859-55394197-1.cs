    [TestMethod]
    public void NamedLifetimeTests()
    {
        var builder = new ContainerBuilder();
        builder.Register(c => new ChildA()).As<Parent>().InstancePerLifetimeScope();    
    
        var container = builder.Build();
        using (var scope = container.BeginLifetimeScope())
        {
            var parent = scope.Resolve<Parent>();
            Assert.IsTrue(parent.GetType() == typeof(ChildA));
        }
    
        using (var scope = container.BeginLifetimeScope("system"), cb => { cb.RegisterType<ChildB>().As<Parent>(); }))
        {
            var parent = scope.Resolve<Parent>();
            Assert.IsTrue(parent.GetType() == typeof(ChildB));
        }
    }
