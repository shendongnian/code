    class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("https://localhost:11011");
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
    
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
                    sh.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
                    sh.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustUserNamePasswordVal();
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
                    sh.Close();
                    Console.ReadLine();
                }
    
            }
        }
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string SayHello();
        }
        public class MyService : IService
        {
            public string SayHello()
            {
                return $"Hello Stranger,{DateTime.Now.ToLongTimeString()}";
            }
        }
        internal class CustUserNamePasswordVal : UserNamePasswordValidator
        {
            public override void Validate(string userName, string password)
            {
                if (userName != "jack" || password != "123456")
                {
                    throw new Exception("Username/Password is not correct");
                }
            }
        }
