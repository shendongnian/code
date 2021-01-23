    public static ServiceHost CreateServiceHost(Type serviceInterface, Type implementation)
    {
      //Create base address
      string baseAddress = "net.pipe://localhost/MyService";
      ServiceHost serviceHost = new ServiceHost(implementation, new Uri(baseAddress));
      //Net named pipe
      NetNamedPipeBinding binding = new NetNamedPipeBinding { MaxReceivedMessageSize = 2147483647 };
      serviceHost.AddServiceEndpoint(serviceInterface, binding, baseAddress);
      //MEX - Meta data exchange
      ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
      serviceHost.Description.Behaviors.Add(behavior);
      serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexNamedPipeBinding(), baseAddress + "/mex/");
      return serviceHost;
    }
