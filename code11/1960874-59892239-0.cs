    class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("https://localhost:21011");
                MtomMessageEncodingBindingElement encoding = new MtomMessageEncodingBindingElement();
                var transport = new HttpsTransportBindingElement();
                transport.TransferMode = TransferMode.Streamed;
                var binding = new CustomBinding(encoding, transport);
                using (ServiceHost sh = new ServiceHost(typeof(MyService), uri))
                {
                    sh.AddServiceEndpoint(typeof(IService), binding, "");
                    ServiceMetadataBehavior smb;
                    smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    if (smb == null)
                    {
                        smb = new ServiceMetadataBehavior()
                        {
                            HttpsGetEnabled = true
                        };
                        sh.Description.Behaviors.Add(smb);
                    }
                    Binding mexbinding = MetadataExchangeBindings.CreateMexHttpsBinding();
                    sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
    
    
                    sh.Opened += delegate
                    {
                        Console.WriteLine("Service is ready");
                    };
                    sh.Closed += delegate
                    {
                        Console.WriteLine("Service is clsoed");
                    };
                    sh.Open();
                    Console.ReadLine();
                    //pause
                    sh.Close();
                    Console.ReadLine();
                }
            }
        }
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string Test();
    
        }
        public class MyService : IService
        {
            public string Test()
            {
                return DateTime.Now.ToLongTimeString();
            }
    }
