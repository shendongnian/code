    public class StackOverflow_6073581_751090
    {
        [ServiceContract]
        public interface ITest
        {
            [WebGet(UriTemplate = "/API/{id}")]
            string Get(string id);
        }
        public class Service : ITest
        {
            public string Get(string id)
            {
                return id;
            }
        }
        public class MyBehavior : WebHttpBehavior
        {
            protected override WebHttpDispatchOperationSelector GetOperationSelector(ServiceEndpoint endpoint)
            {
                return new MySelector(endpoint);
            }
            class MySelector : WebHttpDispatchOperationSelector
            {
                public MySelector(ServiceEndpoint endpoint) : base(endpoint) { }
                protected override string SelectOperation(ref Message message, out bool uriMatched)
                {
                    string result = base.SelectOperation(ref message, out uriMatched);
                    if (!uriMatched)
                    {
                        string address = message.Headers.To.AbsoluteUri;
                        if (address.EndsWith("/"))
                        {
                            message.Headers.To = new Uri(address.Substring(0, address.Length - 1));
                        }
                        result = base.SelectOperation(ref message, out uriMatched);
                    }
                    return result;
                }
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "").Behaviors.Add(new MyBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/API/2"));
            Console.WriteLine(c.DownloadString(baseAddress + "/API/2/"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
