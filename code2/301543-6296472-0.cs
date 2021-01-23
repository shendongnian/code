    public class StackOverflow_6267090
    {
        static bool useHttp;
        const string baseAddressHttp = "http://localhost:8000/Bug/";
        const string baseAddressPipe = "net.pipe://localhost/Bug/";
        static Binding GetBinding()
        {
            if (useHttp)
            {
                return new BasicHttpBinding();
            }
            else
            {
                return new NetNamedPipeBinding();
            }
        }
        static string GetBaseAddress()
        {
            return useHttp ? baseAddressHttp : baseAddressPipe;
        }
        [ServiceContract]
        public interface IInner
        {
            [OperationContract]
            [FaultContract(typeof(Detail))]
            int DoStuff();
        }
        [ServiceContract]
        public interface IOuter
        {
            [OperationContract]
            [FaultContract(typeof(Detail))]
            int DoStuff();
        }
        [DataContract]
        public class Detail
        {
            [DataMember]
            public string Data { get; set; }
            public override string ToString()
            {
                return string.Format("Detail[Data={0}]", Data);
            }
        }
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class InnerService : IInner
        {
            public int DoStuff()
            {
                //return 3;
                throw new FaultException<Detail>(new Detail { Data = "Something" }, new FaultReason("My special reason"));
            }
        }
        class OuterService : IOuter
        {
            public int DoStuff()
            {
                return Caller.CallInner("In service");
            }
        }
        public static class Caller
        {
            public static int CallInner(string where)
            {
                try
                {
                    var factory = new ChannelFactory<IInner>(GetBinding(), new EndpointAddress(GetBaseAddress() + "Inner/"));
                    var channel = factory.CreateChannel();
                    int result = channel.DoStuff();
                    return result;
                }
                catch (FaultException<Detail> e)
                {
                    Console.WriteLine("[{0} - CallInner] Error, Message={1}, Detail={2}", where, e.Message, e.Detail);
                    throw;
                }
            }
            public static int CallOuter(string where)
            {
                try
                {
                    var factory = new ChannelFactory<IOuter>(GetBinding(), new EndpointAddress(GetBaseAddress() + "Outer/"));
                    var channel = factory.CreateChannel();
                    int result = channel.DoStuff();
                    return result;
                }
                catch (FaultException<Detail> e)
                {
                    Console.WriteLine("[{0} - CallOuter] Error, Message={1}, Detail={2}", where, e.Message, e.Detail);
                    throw;
                }
            }
        }
        public static void TestWith(bool useHttp)
        {
            StackOverflow_6267090.useHttp = useHttp;
            Console.WriteLine("Using address: {0}", GetBaseAddress());
            string baseAddress = GetBaseAddress();
            ServiceHost innerHost = new ServiceHost(typeof(InnerService), new Uri(baseAddress + "Inner/"));
            ServiceHost outerHost = new ServiceHost(typeof(OuterService), new Uri(baseAddress + "Outer/"));
            innerHost.AddServiceEndpoint(typeof(IInner), GetBinding(), "");
            outerHost.AddServiceEndpoint(typeof(IOuter), GetBinding(), "");
            innerHost.Open();
            outerHost.Open();
            Console.WriteLine("Hosts opened");
            Console.WriteLine("Calling inner directly");
            try
            {
                Console.WriteLine(Caller.CallInner("client"));
            }
            catch (FaultException<Detail> e)
            {
                Console.WriteLine("In client, after CallInner, Message = {0}, Detail = {1}", e.Message, e.Detail);
            }
            Console.WriteLine("Calling outer");
            try
            {
                Console.WriteLine(Caller.CallOuter("client"));
            }
            catch (FaultException<Detail> e)
            {
                Console.WriteLine("In client, after CallOuter, Message = {0}, Detail = {1}", e.Message, e.Detail);
            }
            catch (FaultException e)
            {
                Console.WriteLine("BUG BUG - this should not have arrived here. Exception = {0}", e);
            }
        }
        public static void Test()
        {
            TestWith(true);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            TestWith(false);
        }
    }
