    public class StackOverflow_5189844_751090
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            TestObject Load();
        }
        [DataContract]
        [KnownType(typeof(Collection<object>))]
        public class TestObject
        {
            [DataMember]
            public Collection<object> Properties = new Collection<object>();
        }
        public class Service1 : IService1
        {
            public TestObject Load()
            {
                var obj = new TestObject();
                // bad line
                obj.Properties.Add(new Collection<object>());
                return obj;
            }
        }
        static Binding GetBinding()
        {
            BasicHttpBinding result = new BasicHttpBinding();
            //Change binding settings here
            return result;
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service1), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IService1), GetBinding(), "");
            host.Open();
            Console.WriteLine("Host opened");
            var factory = new ChannelFactory<IService1>(GetBinding(), new EndpointAddress(baseAddress));
            var proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Load());
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
