    public interface IBase
    {
        string Id { get; set; }
    }
    public interface IService
    {
        IBase Call<T>() where T : class, IBase;
    }
    public class ReturnType1 : IBase
    {
        public string Id { get; set; }
        public string PropertyOne { get; set; }
        public string PropertyTwo { get; set; }
    }
    public class Service1 : IService
    {
        public ReturnType1 ReturnType { get; set; }
        IBase IService.Call<T>()
        {
            return new ReturnType1();
        }
    }
    public class ClientApp
    {
        private static void Main(string[] args)
        {
            IService svc1 = new Service1();
            IBase result = svc1.Call<ReturnType1>();
            Console.WriteLine(result.GetType());
        }
    }
