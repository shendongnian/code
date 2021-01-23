    public class InstanceProviderBehaviorAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription,
                ServiceHostBase serviceHostBase,
                Collection<ServiceEndpoint> endpoints,
                BindingParameterCollection bindingParameters)
        {}
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
                ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher ed in cd.Endpoints)
                {
                    if (!ed.IsSystemEndpoint)
                    {
                        ed.DispatchRuntime.InstanceProvider = new ServiceInstanceProvider();
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription,
                ServiceHostBase serviceHostBase)
        {}
    }
