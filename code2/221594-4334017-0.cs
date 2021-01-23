    class Program
    {
        [ServiceContract]
        public interface IMyService
        {
            [OperationContract]
            void Test();
        }
    
        public class MyService : IMyService
        {
            public void Test()
            {
                throw new NotImplementedException();
            }
        }
    
        static void Main()
        {
            var endpointAddress = new Uri("http://127.0.0.1:5555/MyService");
            using (var host = new ServiceHost(typeof(MyService), endpointAddress))
            {
                var basicHttpBinding = new BasicHttpBinding();
                host.AddServiceEndpoint(typeof(IMyService), basicHttpBinding, string.Empty);
                host.Open();
            }
        }
    }
