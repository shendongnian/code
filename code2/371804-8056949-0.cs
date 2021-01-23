    static void Main(string[] args)
    {
        var address = "net.pipe://localhost/test";
        host = new ServiceHost(typeof(Remote));
        host.AddServiceEndpoint(typeof(IRemote), new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), address);
        host.Open();
        proxy = ChannelFactory<IRemote>.CreateChannel(new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), new EndpointAddress(address));
        TestWcf(Iterations);
        TestRemoting(Iterations);
        TestWcf(Iterations);
        TestRemoting(Iterations);
        TestWcf(Iterations);
        TestRemoting(Iterations);
        host.Close();
        Console.ReadKey();
    }
