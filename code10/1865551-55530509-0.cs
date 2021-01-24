    class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("http://localhost:1100");
                BasicHttpBinding binding = new BasicHttpBinding();
                using (ServiceHost sh = new ServiceHost(typeof(MyService), uri))
                {
                    ServiceEndpoint se = sh.AddServiceEndpoint(typeof(IService), binding, "");
                    ServiceMetadataBehavior smb;
                    smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    if (smb == null)
                    {
                        smb = new ServiceMetadataBehavior();
                        smb.HttpGetEnabled = true;
                        smb.HttpGetUrl = new Uri("http://localhost:1100/mex");
                        sh.Description.Behaviors.Add(smb);
                    }
                    MyEndpointBehavior bhv = new MyEndpointBehavior();
                    se.EndpointBehaviors.Add(bhv);
    
    
                    sh.Open();
                    Console.WriteLine("service is ready");
                    Console.ReadKey();
                    sh.Close();
                }
            }
        }
        [ServiceContract(ConfigurationName = "isv")]
        public interface IService
        {
            [OperationContract]
            string Delete(int value);
            [OperationContract]
            void UpdateAll();
        }
        [ServiceBehavior(ConfigurationName = "sv")]
        public class MyService : IService
        {
            public string Delete(int value)
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Parameter should be greater than 0");
                }
                return "Hello";
            }
    
            public void UpdateAll()
            {
                throw new InvalidOperationException("Operation exception");
            }
        }
        public class MyCustomErrorHandler : IErrorHandler
        {
            public bool HandleError(Exception error)
            {
                return true;
            }
    
            public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
            {
                FaultException faultException = new FaultException(error.Message);
                MessageFault messageFault = faultException.CreateMessageFault();
                fault = Message.CreateMessage(version, messageFault, error.Message);
            }
        }
        public class MyEndpointBehavior : IEndpointBehavior
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
                MyCustomErrorHandler myCustomErrorHandler = new MyCustomErrorHandler();
                endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(myCustomErrorHandler);
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
                return;
            }
    }
