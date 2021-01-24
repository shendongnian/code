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
            string GetData();
        }
        public class MyService : IService
        {
            public string GetData()
            {
                return DateTime.Now.ToString();
            }
        }
        public class MyValidator : UserNamePasswordValidator
        {
            public override void Validate(string userName, string password)
            {
                if (userName != "jack" || password != "123456")
                {
                    throw new Exception("My Error");
                }
    
            }
        }
