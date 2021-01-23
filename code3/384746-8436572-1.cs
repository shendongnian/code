    interface IDependency
    {
        string GetName();
    }
    class ConcreteDependency : IDependency
    {
        public string GetName()
        {
            return "Concrete Dependency";
        }
    }
    class ConstructorExample
    {
        readonly IDependency dependency;
        public ConstructorExample(IDependency dependency)
        {
            this.dependency = dependency;
        }
        public string GetString()
        {
            return "Consumer of " + dependency.GetName();
        }
    }
    class SetterExample
    {
        public IDependency Dependency { get; set; }
        public string GetString()
        {
            return "Consumer of " + Dependency.GetName();
        }
    }
    [TestMethod]
    public void MyTestMethod()
    {
        var container = new Container();
        container.Register<IDependency>(c => new ConcreteDependency());
        container.Register(c => new ConstructorExample(c.Resolve<IDependency>()));
        container.Register(c => new SetterExample() { Dependency = c.Resolve<IDependency>() });
        var constructor = container.Resolve<ConstructorExample>();
        Assert.AreEqual("Consumer of Concrete Dependency", constructor.GetString());
        var setter = container.Resolve<SetterExample>();
        Assert.AreEqual("Consumer of Concrete Dependency", constructor.GetString());
    }
