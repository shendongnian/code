    ServiceHost host = new ServiceHost(typeof(MyService));
    ServiceMetadataBehavior metadataBehavior;
    metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
    if(metadataBehavior == null)
    {
        Debug.Assert(BaseAddresses.Any(baseAddress=>baseAddress.Uri.Scheme == "http"));
        metadataBehavior = new ServiceMetadataBehavior();
        metadataBehavior.HttpGetEnabled = true;
        host.Description.Behaviors.Add(metadataBehavior);
    }
    host.Open();
