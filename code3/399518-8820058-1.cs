    namespace wcfStarter
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (ServiceHost host = new ServiceHost(typeof(Message), new Uri("http://localhost:8002/HelloWCF")))
                {
                    // Set up a service endpoint [Contract, Binding, Address]
                    host.AddServiceEndpoint(typeof(IMessage), new WSDualHttpBinding() { ClientBaseAddress = new Uri("http://locahost:8001") }, "HelloWCF");
    
                    // Enable metadata exchange
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior() {HttpGetEnabled =true };
    
                    host.Description.Behaviors.Add(smb);
                    host.Open();
    
                    Console.WriteLine("Ready...");
                    Console.ReadLine();
                }
            }
        }
    }
