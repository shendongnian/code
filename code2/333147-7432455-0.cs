    ServiceDebugBehavior serviceDebugBehavior = this.Description.Behaviors.Find<ServiceDebugBehavior>();
      if (serviceDebugBehavior != null)
      {
        serviceDebugBehavior.HttpHelpPageEnabled = false;
        serviceDebugBehavior.HttpsHelpPageEnabled = false;
      }
      ServiceMetadataBehavior metadataBehavior = this.Description.Behaviors.Find<ServiceMetadataBehavior>();
      if (metadataBehavior != null)
      {
        metadataBehavior.HttpGetEnabled = false;
        metadataBehavior.HttpsGetEnabled = false;
      }
