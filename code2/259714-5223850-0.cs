    ServiceHost serviceHost = new ServiceHost(typeof(StockService), new Uri("http://localhost:8000/wcfLib"));
    serviceHost.AddServiceEndpoint(typeof(IfaceService), new BasicHttpBinding(), "");
    serviceHost.Open();
    Console.WriteLine("Press return to terminate the service");
    Console.ReadLine();
    serviceHost.Close();
    
