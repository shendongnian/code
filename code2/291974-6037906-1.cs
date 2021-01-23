    var factory = new ObjectFactory();
    factory.Register<MyObjectA>(MyObjectType.A);
    factory.Register<MyObjectB>(MyObjectType.B);
    var a = factory.CreateInstance(MyObjectType.A);
    var b = factory.CreateInstance(MyObjectType.B);
    Assert.IsInstanceOf(typeof(MyObjectA), a);
    Assert.IsInstanceOf(typeof(MyObjectB), b);
