        public class StackOverflow_5999249_751090
    {
        [ServiceContract(Name = "ITest", Namespace = "")]
        public interface ITest
        {
            [OperationContract]
            string Echo(string path);
        }
        public class Service : ITest
        {
            public string Echo(string path) { return path; }
        }
        [ServiceContract(Name = "ITest", Namespace = "")]
        public interface ITestClient_Wrong
        {
            [OperationContract]
            IAsyncResult BeginEcho(string path, AsyncCallback callback, object state);
            string EndEcho(IAsyncResult asyncResult);
        }
        [ServiceContract(Name = "ITest", Namespace = "")]
        public interface ITestClient_Correct
        {
            [OperationContract(AsyncPattern = true)]
            IAsyncResult BeginEcho(string path, AsyncCallback callback, object state);
            string EndEcho(IAsyncResult asyncResult);
        }
        static void PrintException(Exception e)
        {
            int indent = 2;
            while (e != null)
            {
                for (int i = 0; i < indent; i++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine("{0}: {1}", e.GetType().FullName, e.Message);
                indent += 2;
                e = e.InnerException;
            }
        }
        public static void Test()
        {
            string baseAddress = "net.pipe://localhost/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), new NetNamedPipeBinding(), "");
            host.Open();
            Console.WriteLine("Host opened");
            AutoResetEvent evt = new AutoResetEvent(false);
            Console.WriteLine("Correct");
            ChannelFactory<ITestClient_Correct> factory1 = new ChannelFactory<ITestClient_Correct>(new NetNamedPipeBinding(), new EndpointAddress(baseAddress));
            ITestClient_Correct proxy1 = factory1.CreateChannel();
            proxy1.BeginEcho("Hello", delegate(IAsyncResult ar)
            {
                Console.WriteLine("Result from correct: {0}", proxy1.EndEcho(ar));
                evt.Set();
            }, null);
            evt.WaitOne();
            Console.WriteLine("Wrong");
            ChannelFactory<ITestClient_Wrong> factory2 = new ChannelFactory<ITestClient_Wrong>(new NetNamedPipeBinding(), new EndpointAddress(baseAddress));
            ITestClient_Wrong proxy2 = factory2.CreateChannel();
            try
            {
                proxy2.BeginEcho("Hello", delegate(IAsyncResult ar)
                {
                    try
                    {
                        Console.WriteLine("Result from wrong: {0}", proxy2.EndEcho(ar));
                    }
                    catch (Exception e)
                    {
                        PrintException(e);
                    }
                    evt.Set();
                }, null);
                evt.WaitOne();
            }
            catch (Exception e2)
            {
                PrintException(e2);
            }
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            host.Close();
        }
    }
