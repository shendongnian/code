    public class StackOverflow_6846215
    {
        [ServiceContract(Name = "ITest")]
        public interface ITest
        {
            [OperationContract]
            [WebGet]
            int Add(int x, int y);
        }
        [ServiceContract(Name = "ITest")]
        public interface ITestClient
        {
            [OperationContract(AsyncPattern = true)]
            IAsyncResult BeginAdd(int x, int y, AsyncCallback callback, object state);
            int EndAdd(IAsyncResult asyncResult);
            [OperationContract]
            [WebGet]
            int Add(int x, int y);
        }
        public class Client : ClientBase<ITestClient>, ITestClient
        {
            public Client(string baseAddress)
                :base(new WebHttpBinding(), new EndpointAddress(baseAddress))
            {
                this.Endpoint.Behaviors.Add(new WebHttpBehavior());
            }
            public IAsyncResult BeginAdd(int x, int y, AsyncCallback callback, object state)
            {
                return this.Channel.BeginAdd(x, y, callback, state);
            }
            public int EndAdd(IAsyncResult asyncResult)
            {
                return this.Channel.EndAdd(asyncResult);
            }
            public int Add(int x, int y)
            {
                return this.Channel.Add(x, y);
            }
        }
        public class Service : ITest
        {
            public int Add(int x, int y)
            {
                return x + y;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            Client client = new Client(baseAddress);
            Console.WriteLine("Sync result: {0}", client.Add(66, 77));
            client.BeginAdd(44, 55, delegate(IAsyncResult ar)
            {
                int result = client.EndAdd(ar);
                Console.WriteLine("Async result: {0}", result);
            }, null);
            Console.WriteLine("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
