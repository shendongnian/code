     class AuthenticationBehaviour : IEndpointBehavior
    {
        #region IEndpointBehavior Members
    
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            AuthenticationMessageInspector inspector = new AuthenticationMessageInspector();
            clientRuntime.MessageInspectors.Add(inspector);
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            //AuthenticationMessageInspector inspector = new AuthenticationMessageInspector();
            //endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
        }
    
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    
        class AuthenticationMessageInspector : IClientMessageInspector
    {
        private const string HeaderKey = "Authentication";
    
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
    
            if (Session.MachineId == 0)
            {
                Session.MachineId = LicenseGenerator.GenerateLicense();
            }
            
    
            request.Headers.Add(MessageHeader.CreateHeader(HeaderKey, string.Empty, Session.MachineId));
            return null;
        }
    
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
           
        }
    }
