    // get the <system.serviceModel> / <services> config section
    ServicesSection services = ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;
    ServiceHost host = new ServiceHost(typeof(SelfHostedService.Service));
    // enumerate over each <service> node
    foreach (ServiceElement aService in services.Services)
    {
        Console.WriteLine();
        Console.WriteLine("Name: {0} / Behavior: {1}", aService.Name, aService.BehaviorConfiguration);
        // enumerate over all endpoints for that service
        foreach (ServiceEndpointElement see in aService.Endpoints)
        {
            Console.WriteLine("\tEndpoint: Address = {0} / Binding = {1} / Contract = {2}", see.Address, see.Binding, see.Contract);
            //host.AddServiceEndpoint(
        }
    }
    try
    {
        Console.WriteLine("Service EndPoints are: ");
        foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
        {
            Console.WriteLine("{0} ({1})", endpoint.Address.ToString(), endpoint.Binding.Name);
        }
        host.Open();
                
        Console.WriteLine(string.Concat("Service is host at ", DateTime.Now.ToString()));
        Console.WriteLine("\n Self Host is running... Press <Enter> key to stop");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message.ToString());
    }
