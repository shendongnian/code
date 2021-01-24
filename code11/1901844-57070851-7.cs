     class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost sh = new ServiceHost(typeof(MyService)))
            {
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
            return DateTime.Now.ToLongTimeString();
        }
    }
