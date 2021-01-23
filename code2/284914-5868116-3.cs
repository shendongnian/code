    class Program
    {
        static void Main(string[] args)
        {
            using (var instance = new ClassA().Wrap())
            {
                ClassA instanceA = instance;
            }
            using (var instance = new ClassB().Wrap())
            {
                ClassB instanceB = instance;   
            }
            Console.ReadKey();
        }
    }
    public class ClassA
    {
        
    }
    public class ClassB : IDisposable
    {
        public void Dispose()
        {
            Console.Write("Disposed");
        }
    }
