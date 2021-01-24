    class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("net.tcp://localhost:1900");
                NetTcpBinding binding = new NetTcpBinding();
                using (ServiceHost sh=new ServiceHost(typeof(MyService),uri))
                {
                    sh.AddServiceEndpoint(typeof(IService), binding, "");
                    ServiceMetadataBehavior smb;
                    smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    if (smb == null)
                    {
                        smb = new ServiceMetadataBehavior()
                        {
                        };
                        sh.Description.Behaviors.Add(smb);
                    }
                    ServiceDiscoveryBehavior sdb = new ServiceDiscoveryBehavior();
                    sdb.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
                    sh.Description.Behaviors.Add(sdb);
                    sh.AddServiceEndpoint(new UdpDiscoveryEndpoint());
    
                    Binding binding1 = MetadataExchangeBindings.CreateMexTcpBinding();
                    sh.AddServiceEndpoint(typeof(IMetadataExchange), binding1, "mex");
                    sh.Open();
                    Console.WriteLine("Service is ready...");
    
                    Console.ReadLine();
                    sh.Close();
                }
    
            }
        }
        [ServiceContract(Namespace ="mydomain")]
        public interface IService
        {
            [OperationContract(Name ="AddInt")]
            int Add(int x, int y);
            
        }
        public class MyService : IService
        {
            public int Add(int x, int y)
            {
                return x + y;
            }
    }
