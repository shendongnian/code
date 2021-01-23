    public class StackOverflow_7771645
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string Process();
        }
        public class Service : ITest
        {
            public string Process()
            {
                return "Request content type: " + WebOperationContext.Current.IncomingRequest.ContentType;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebChannelFactory<ITest> factory = new WebChannelFactory<ITest>(new Uri(baseAddress));
            ITest proxy = factory.CreateChannel();
            using (new OperationContextScope((IContextChannel)proxy))
            {
                WebOperationContext.Current.OutgoingRequest.ContentType = "text/xml";
                Console.WriteLine(proxy.Process());
            }
            using (new OperationContextScope((IContextChannel)proxy))
            {
                WebOperationContext.Current.OutgoingRequest.ContentType = "application/xml";
                Console.WriteLine(proxy.Process());
            }
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
