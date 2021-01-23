     ServicesSection servicesSection = (ServicesSection)WebConfigurationManager.GetSection("system.serviceModel/services");  
    for(int i = 0;i<servicesSection.Services.Count;i++)
    {
    ServiceEndpointElement endpoint = servicesSection.Services[i].Endpoints[0];  
    string url = string.Format("net.tcp://{0}:{1}/YouNameSpace_MyService/{2}.svc","YourHost","YourPort");
      ServiceHost serviceHost = new ServiceHost(mappings[endpoint.Contract] , new Uri(url));
    
              serviceHost.Open();
    
              mServiceHosts.Add(serviceHost);
    }
