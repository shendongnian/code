    public class StackOverflow_7068743
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string Echo(string text);
        }
        public class Service : ITest
        {
            public string Echo(string text)
            {
                return text + " (via " + OperationContext.Current.IncomingMessageHeaders.To + ")";
            }
        }
        public static void Test()
        {
            string baseAddressHttp = "http://" + Environment.MachineName + ":8000/Service";
            string baseAddressPipe = "net.pipe://localhost/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddressHttp), new Uri(baseAddressPipe));
            host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            host.AddServiceEndpoint(new UdpDiscoveryEndpoint());
            host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "");
            host.AddServiceEndpoint(typeof(ITest), new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), "");
            host.Open();
            Console.WriteLine("Host opened");
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(ITest)));
            Console.WriteLine(findResponse.Endpoints.Count);
            EndpointAddress address = null;
            Binding binding = null;
            foreach (var endpoint in findResponse.Endpoints)
            {
                if (endpoint.Address.Uri.Scheme == Uri.UriSchemeHttp)
                {
                    address = endpoint.Address;
                    binding = new BasicHttpBinding();
                }
                else if (endpoint.Address.Uri.Scheme == Uri.UriSchemeNetPipe)
                {
                    address = endpoint.Address;
                    binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                    break; // this is the preferred
                }
                Console.WriteLine(endpoint.Address);
            }
            if (binding == null)
            {
                Console.WriteLine("No known bindings");
            }
            else
            {
                ChannelFactory<ITest> factory = new ChannelFactory<ITest>(binding, address);
                ITest proxy = factory.CreateChannel();
                Console.WriteLine(proxy.Echo("Hello"));
                ((IClientChannel)proxy).Close();
                factory.Close();
            }
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
