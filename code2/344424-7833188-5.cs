    var serviceHost = new ServiceHost
            (typeof(Service), new Uri[] { new Uri("net.pipe://localhost/") });
        serviceHost.AddServiceEndpoint(typeof(IService), new NetNamedPipeBinding(), "helloservice");
        serviceHost.Open();
     
        Console.WriteLine("Service started. Available in following endpoints");
        foreach (var serviceEndpoint in serviceHost.Description.Endpoints)
        {
            Console.WriteLine(serviceEndpoint.ListenUri.AbsoluteUri);
        }
