    // Add behavior for Services - enable WSDL access
    ServiceMetadataBehavior serviceABehavior = new ServiceMetadataBehavior();
    serviceABehavior.HttpGetEnabled = true;
    serviceABehavior.HttpGetUrl = new Uri("http://localhost:8080/ServiceA");
    serviceAHost.Description.Behaviors.Add(serviceABehavior);
    ServiceMetadataBehavior serviceBBehavior = new ServiceMetadataBehavior();
    serviceBBehavior.HttpGetEnabled = true;
    serviceBBehavior.HttpGetUrl = new Uri("http://localhost:8080/ServiceB");
    serviceBHost.Description.Behaviors.Add(serviceBBehavior);
    // Create basicHttpBinding endpoint at http://localhost:8080/ServiceA/  
    serviceAHost.AddServiceEndpoint(serviceAContractType, new BasicHttpBinding(), 
    "http://localhost:8080/ServiceA");
    // Create basicHttpBinding endpoint at http://localhost:8080/ServiceB/  
    serviceBHost.AddServiceEndpoint(serviceBContractType, new BasicHttpBinding(), 
    "http://localhost:8080/ServiceB");
