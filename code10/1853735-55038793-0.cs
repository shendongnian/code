    class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("http://localhost:1300");
                IService service = ChannelFactory<IService>.CreateChannel(new BasicHttpBinding(), new EndpointAddress(uri));
                try
                {
                    Console.WriteLine(service.SayHello());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    
        [ServiceContract(Namespace = "mydomain")]
        [CustomContractBehavior]
        public interface IService
        {
            [OperationContract]
            string SayHello();
        }
    
        public class ClientMessageLogger : IClientMessageInspector
        {
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                string displayText = $"the client has received the reply:\n{reply}\n";
                Console.Write(displayText);
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
    		//Add custom message header
                request.Headers.Add(MessageHeader.CreateHeader("myheader","mynamespace",2000));
                string displayText = $"the client send request message:\n{request}\n";
                Console.WriteLine(displayText);
                return null;
                
            }
        }
    
        public class CustomContractBehaviorAttribute : Attribute, IContractBehavior, IContractBehaviorAttribute
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
