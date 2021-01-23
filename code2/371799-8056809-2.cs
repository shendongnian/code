    private static void TestWcf(int iterations)
    {
      var address = "net.pipe://localhost/test";
      var host = new ServiceHost(typeof(Remote));
      host.AddServiceEndpoint(typeof(IRemote), new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), address);
      host.Open();
      var proxy = ChannelFactory<IRemote>.CreateChannel(new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), new EndpointAddress(address));
      Console.WriteLine("Wcf: {0} ms.", Test(proxy, iterations));
      host.Close();
    }
