    using System.ServiceModel;
    using System.ServiceModel.Activation;
    
    namespace your.namespace.here
    {
        public class CustomServiceHostFactory : WebServiceHostFactory
        {
            protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
            {
                ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
                //note: these endpoints will not exist yet, if you are relying on the svc system to generate your endpoints for you
                // calling host.AddDefaultEndpoints provides you the endpoints you need to add the behavior we need.
                var endpoints = host.AddDefaultEndpoints();
                foreach (var endpoint in endpoints)
                {
                    endpoint.Behaviors.Add(new WcfUnkownUriBehavior());
                }
    
                return host;
            }
        }
    }
