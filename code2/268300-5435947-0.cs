    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Sample s1 = Activator.CreateInstance(typeof(Sample)) as Sample;
            s1.SayHello();
        }
    }
    
    public class Sample
    {
        public void SayHello()
        {
            Console.WriteLine("Hello World");
        }
    }
