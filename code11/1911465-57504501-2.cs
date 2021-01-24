    class Program
    {
        /// <summary>
        /// https webhttpbinding.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Uri uri = new Uri("https://localhost:4386");
            WebHttpBinding binding = new WebHttpBinding();
            binding.Security.Mode = WebHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            
           
            using (WebServiceHost sh = new WebServiceHost(typeof(TestService), uri))
            {
                sh.AddServiceEndpoint(typeof(ITestService), binding, "");
                ServiceMetadataBehavior smb;
                smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior()
                    {
                        //HttpsGetEnabled = true
                    };
                    sh.Description.Behaviors.Add(smb);
                }
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpsBinding();
                sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
                sh.Opened += delegate
                {
                    Console.WriteLine("service is ready");
                };
                sh.Closed += delegate
                {
                    Console.WriteLine("service is closed");
                };
                sh.Open();
                Console.ReadLine();
                sh.Close();
            }
        }
    }
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        [WebGet(ResponseFormat =WebMessageFormat.Json)]
        string GetResult();
    }
    [ServiceBehavior]
    public class TestService : ITestService
    {
        public string GetResult()
        {
            return $"Hello, busy World. {DateTime.Now.ToShortTimeString()}";
        }
    }
