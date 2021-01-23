    public class CallbackHandler : IService1Callback
    {
        public void Progress(string what, decimal percentDone)
        {
            Console.WriteLine("Have done {0:0%} of {1}", percentDone, what);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Setup the client
            var callbacks = new CallbackHandler();
            var endpoint = new EndpointAddress(new Uri("net.tcp://localhost:6789/Service1"));
            using (var factory = new DuplexChannelFactory<IService1>(callbacks, new NetTcpBinding(SecurityMode.None), endpoint))
            {
                var client = factory.CreateChannel();
                client.Process("JOB1");
                Console.ReadLine();
                factory.Close();
            }
        }
    }
