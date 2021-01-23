    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                Type t1 = Type.GetType("ProviderOne.AuthService");
    
                dynamic service = Activator.CreateInstance(t1);
    
                Console.WriteLine(service.GetUsername());
    
                Type t2 = Type.GetType("ProviderTwo.AuthService");
    
                service = Activator.CreateInstance(t2);
                Console.WriteLine(service.GetUsername());
    
                Console.Read();
            }
        }
    }
    
    namespace ProviderOne
    {
        public class AuthService
        {
            public string GetUsername()
            {
                return "Adam";
            }
        }
    }
    
    namespace ProviderTwo
    {
        public class AuthService
        {
            public string GetUsername()
            {
                return "Houldsworth";
            }
        }
    }
