    public interface IClassA
    {
        void DoSomething();
    }
    public class ClassA
    {
        public void DoSomething()
        {
            // do something here
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IClassA obj = new ClassA(); // throws error because ClassA doesn't inherit from IClassA
        }
    }
