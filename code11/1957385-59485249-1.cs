    public class AuthBehavior : BehaviorExtensionElement, IEndpointBehavior
        {
            public override Type BehaviorType => typeof(AuthBehavior);
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                ClientMessageLogger inspector = new ClientMessageLogger();
                clientRuntime.ClientMessageInspectors.Add(inspector);
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
            protected override object CreateBehavior()
            {
                return new AuthBehavior();
            }
        }
