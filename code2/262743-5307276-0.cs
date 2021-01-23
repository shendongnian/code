    namespace WcfService2
    {
        using System;
        using System.ServiceModel;
        using System.ServiceModel.Activation;
    
        public class CustomServiceHostFactory : ServiceHostFactoryBase
        {
            public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
            {
                var host = new ServiceHost(Type.GetType(constructorString), baseAddresses);
                host.AddDefaultEndpoints();
                return host;
            }
        }
    }
