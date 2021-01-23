    namespace ServiceHostConsole
    {
        [ServiceContract]
        public interface ITestService
        {
            [OperationContract]
            string GetData(int value);
        }
        
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class TestService : ITestService
        {
            public TestService()
            {
                CachingProvider.CallCount++;
            }
        
            public string GetData(int value)
            {
                return string.Format("You entered: {0}", value);
            }
        }
        
        //For demonstration purposes only
        static class CachingProvider
        {
            static CachingProvider()
            {
                //private static constructor can initialize 
                //static cacheable resources
                _callCounter = 0; //Trivial example of initialization
            }
        
            private static int _callCounter;
            public static int CallCount
            {
                set { _callCounter = value; }
                get { return _callCounter; }
            }
        }
        
        class Program
        {
            static void Main()
            {
                using (var host = new ServiceHost(typeof(TestService), new Uri("http://localhost/TestService")))
                {
                    host.Open();
        
                    //Example how the ServiceHost can report on a persistent in-memory object that is being
                    //updated each time the service is called.
                    new Timer(state => Console.WriteLine("# of service calls: {0}", CachingProvider.CallCount), null, 0, 5000);
        
                    Console.Read();
                    host.Close();
                }
            }
        }
    }
