    public class MyServiceInstanceProvider<TService> : IInstanceProvider where TService : new()
    {
        public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return ServiceFactory.Create<TService>();
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return ServiceFactory.Create<TService>();
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            return;
        }
    }
    public class MyEndpointBehavior<TService> : IEndpointBehavior where TService : new()
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            return;
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            return;
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.InstanceProvider = new MyServiceInstanceProvider<TService>();
        }
        public void Validate(ServiceEndpoint endpoint)
        {
            return;
        }
    }
    public class MyServiceHost<TService> : ServiceHost where TService : new()
    {
        public MyServiceHost(params Uri[] baseAddresses)
            :base(typeof(TService), baseAddresses)
        {            
        }
        public override System.Collections.ObjectModel.ReadOnlyCollection<ServiceEndpoint> AddDefaultEndpoints()
        {
            var endpoints = base.AddDefaultEndpoints();
            foreach (var endpoint in endpoints)
            {
                endpoint.Behaviors.Add(new MyEndpointBehavior<TService>());
            }
            return endpoints;
        }
        public override void AddServiceEndpoint(ServiceEndpoint endpoint)
        {
            base.AddServiceEndpoint(endpoint);
            endpoint.Behaviors.Add(new MyEndpointBehavior<TService>());
        }
    }
