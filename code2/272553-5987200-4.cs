    public class SoapServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
            ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (smb == null)
            {
                smb = new ServiceMetadataBehavior();
                host.Description.Behaviors.Add(smb);
            }
            smb.HttpGetEnabled = true;
            host.AddServiceEndpoint(serviceType, new BasicHttpBinding(), "soap");
            return host;
        }
    }
