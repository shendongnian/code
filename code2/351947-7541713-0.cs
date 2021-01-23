    ServiceMetadataBehavior meta = new ServiceMetadataBehavior();
          meta.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
          _host.Description.Behaviors.Add(meta);
    
          _host.AddServiceEndpoint(
            ServiceMetadataBehavior.MexContractName,
            MetadataExchangeBindings.CreateMexHttpBinding(),
            "http://localhost:8067/WCFService/mex"
          );
