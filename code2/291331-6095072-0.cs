    static void Main(string[] args)
    {
      TcpClientChannel clientChannel = new TcpClientChannel();
      ChannelServices.RegisterChannel(clientChannel, false);
      Assembly interfaceAssembly = Assembly.LoadFile("RemotingInterface.dll");
      Type iTheInterface = interfaceAssembly.GetType("RemotingInterface.ITheService");
      RemotingConfiguration.RegisterWellKnownClientType(iTheInterface,
                                        "tcp://localhost:9090/Remotable.rem");
      object wellKnownObject = Activator.GetObject(iTheInterface, 
                                        "tcp://localhost:9090/Remotable.rem");
      MethodInfo m = iTheInterface.GetMethod("MethodName");
      m.Invoke(wellKnownObject, new object[] { "Argument"});
    }
