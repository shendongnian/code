    public interface Interface
    {
        string Method<T>();
    }
    
    class Program
    {
        static void Main()
        {
            var mock = new Mock<Interface>();
            mock.Setup(x => x.Method<string>()).Returns("abc");
            Console.WriteLine(mock.Object.Method<string>()); // prints abc
            Console.WriteLine(mock.Object.Method<int>()); // prints nothing
        }
    }
