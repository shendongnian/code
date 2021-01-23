    public class CustomHostFactory
        : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            // perform initialisation:
            ...
            
            var serviceHost = base.CreateServiceHost(serviceType, baseAddresses);
            return serviceHost;
        }
    }
