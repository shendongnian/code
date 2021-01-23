    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        public void Process(string what)
        {
            Console.WriteLine("I'm processing {0}", what);
            for (int i = 0; i < 10; i++)
            {
                OperationContext.Current.GetCallbackChannel<IService1Callback>().Progress(what, (i+1)*0.1M);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
    
            using (ServiceHost host = new ServiceHost( typeof(Service1), new Uri[] { new Uri("net.tcp://localhost:6789") }))
            {
                host.AddServiceEndpoint(typeof(IService1), new NetTcpBinding(SecurityMode.None), "Service1");
                host.Open();
                Console.ReadLine();
                host.Close();
            }
        }
    }
