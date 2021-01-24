    [TestMethod]
    public void registration_returns_expected_type()
    {
        var container = new WindsorContainer();
        container.Register(Component.For<IBar>().ImplementedBy<Bar>());
        var test1 = container.Resolve<IBar>(); //returns Bar
        container.Register(Component.For<Foo>().ImplementedBy<Foo>());
        var test2 = container.Resolve<IBar>();
        Assert.IsInstanceOfType(test2, typeof(Bar));
    }
