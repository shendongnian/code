    object factory = Activator.CreateInstance(genericListType, new object[]
    {
        new BasicHttpBinding(),
        new EndpointAddress("http://localhost:1693/Service.svc")
    });
    Type factoryType = factory.GetType();
    MethodInfo methodInfo = factoryType.GetMethod("CreateChannel");
    var channel = methodInfo.Invoke(factory) as YourChannelType;
