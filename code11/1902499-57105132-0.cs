     class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost sh = new ServiceHost(typeof(MyService)))
            {
                sh.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "cbc81f77ed01a9784a12483030ccd497f01be71c");
                sh.Open();
                Console.WriteLine("serivce is ready....");
                Console.ReadLine();
                sh.Close();
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
            return DateTime.Now.ToString();
        }
    }
