     public void OpenExternalPort(int privatePort, int publicPort, string description)
     {
         localHostPort = privatePort;
         var timeSpan = new TimeSpan(0, 0, 0, 30);
         var cancellationTokenSource = new CancellationTokenSource(timeSpan);
         natDiscoverer = new NatDiscoverer();
         natDevice = natDiscoverer
             .DiscoverDeviceAsync(PortMapper.Upnp, cancellationTokenSource)
             .IsCompleted();
         mapping = new Mapping(Protocol.Tcp, privatePort, publicPort, description);
         natDevice
             .CreatePortMapAsync(mapping)
             .IsCompleted();
     }
