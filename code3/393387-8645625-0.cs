    string interfaceName = "Test";
    Type myInterfaceType = Type.GetType(interfaceName);
    var factoryType = typeof(ChannelFactory<>).MakeGenericType(myInterfaceType);
    var factoryCtr = factoryType.GetConstructor(new []{ typeof(Binding), typeof(EndpointAddress)});
    ChannelFactory factory = factoryCtr.Invoke(new object[]{ new BasicHttpBinding(), new EndpointAddress("")}) as ChannelFactory;
