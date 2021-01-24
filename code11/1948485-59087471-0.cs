    public class ClientMessageLogger : IClientMessageInspector
        {
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                Console.WriteLine(reply);
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                return null;
            }
        }
        public class CustContractBehaviorAttribute : Attribute, IContractBehavior, IContractBehaviorAttribute
        {
            public Type TargetContract => typeof(IService);
    
            public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
                return;
            }
    
            public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.ClientMessageInspectors.Add(new ClientMessageLogger());
            }
    
            public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
            {
                return;
            }
    
            public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
            {
                return;
            }
    }
