    class Program
        {
            static void Main(string[] args)
            {
                using (ServiceHost sh=new ServiceHost(typeof(MyService)))
                {
                    sh.Open();
                    Console.WriteLine("Service is ready....");
    
                    Console.ReadLine();
                    sh.Close();
                }
            }
    
        }
    
        [ServiceContract]
        interface IService
        {
            [OperationContract]
            [WebGet]
            string GetData();
        }
        public class MyService : IService
        {
            public string GetData()
            {
                return DateTime.Now.ToString();
            }
    }
