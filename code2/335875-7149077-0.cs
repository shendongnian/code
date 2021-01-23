    public class StackOverflow_7141998
    {
        [MessageContract]
        public class MyMC
        {
            [MessageHeader(Name = "MyHeader", Namespace = "http://my.namespace.com")]
            public string HeaderValue { get; set; }
            [MessageBodyMember(Name = "MyBody", Namespace = "http://my.namespace.com")]
            public string BodyValue { get; set; }
        }
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            void Process(MyMC mc);
        }
        public class Service : ITest
        {
            public void Process(MyMC mc)
            {
                Console.WriteLine("Header value: {0}", mc.HeaderValue);
            }
        }
        public class MyInspector : IEndpointBehavior, IClientMessageInspector
        {
            public string NewHeaderValue { get; set; }
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.MessageInspectors.Add(this);
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
            }
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                int originalIndex = request.Headers.FindHeader("MyHeader", "http://my.namespace.com");
                if (originalIndex >= 0)
                {
                    request.Headers.Insert(originalIndex, MessageHeader.CreateHeader("MyHeader", "http://my.namespace.com", this.NewHeaderValue));
                    request.Headers.RemoveAt(originalIndex + 1);
                }
                return null;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), new WSHttpBinding(), "");
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new WSHttpBinding(), new EndpointAddress(baseAddress));
            MyInspector inspector = new MyInspector { NewHeaderValue = "Modified header value" };
            factory.Endpoint.Behaviors.Add(inspector);
            ITest proxy = factory.CreateChannel();
            proxy.Process(new MyMC { HeaderValue = "Original header value", BodyValue = "The body" });
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
