    var binding = new WebHttpBinding()
    {
        Security = {
            Mode = WebHttpSecurityMode.Transport
        }
    };
    var baseUri = new Uri("https://localhost:443");
    using (ServiceHost sh = new ServiceHost(typeof(Service1), baseUri))
    {
    	var metadata = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
    	if (metadata == null) {
    		metadata = new ServiceMetadataBehavior();
    		sh.Description.Behaviors.Add(metadata);
    	}
    	metadata.HttpsGetEnabled = true;
    
    	var endpoint = sh.AddServiceEndpoint(typeof(IService1), binding, "/");
    	endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
    	
    	Console.WriteLine("Service is ready....");
    	sh.Open();
    
    	Console.WriteLine("Service started. Press <ENTER> to close.");
    	Console.ReadLine();
    	sh.Close();
    }
