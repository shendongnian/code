    var binding = new NetNamedPipeBinding();
    binding.MaxConnections = 10;
    binding.OpenTimeout = TimeSpan.FromMinutes(0.5);
    binding.CloseTimeout = TimeSpan.FromMinutes(0.5);
    binding.ReceiveTimeout = TimeSpan.FromMinutes(0.5);
    binding.SendTimeout = TimeSpan.FromMinutes(0.5);
    // Compose URIs
    Uri uriBase = new Uri(baseAddress);
    Uri uri = new Uri(baseAddress + something);
    Uri uriMex = new Uri(baseAddress + something + "/mex");
    // Create End Points
    SomeHost = new CustomServiceHost(typeof(TestService), uriBase);
    SomeHost.AddServiceEndpoint(typeof(ITestService), binding, uri);
    SomeHost.AddServiceEndpoint(typeof(IMetadataExchange), binding, uriMex);
    // Open the ServiceHost
    SomeHost.Open();
