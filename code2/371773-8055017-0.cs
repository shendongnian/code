    class Program
    {
        static void Main(string[] args)
        {
            var mock = new Mock<UserService> { CallBase = true };
            mock.Setup(m => m.Method2()).Returns("Mock 2");
    
            Console.WriteLine(mock.Object.Method1());
            Console.ReadLine();
        }
    }
    
    public class UserService
    {
        public virtual string Method1()
        {
            return "Method 1 :: " + Method2();
        }
    
        public virtual string Method2()
        {
            return "Method 2";
        }
    }
