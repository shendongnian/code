    interface IA 
    {
        void Test();
    }
    interface IB
    {
        void Test();
    }
    class Sample: IA, IB
    {
        public void IA.Test()
        {
          Console.WriteLine("Hi from IA");
        }
        public void IB.Test()
        {
          Console.WriteLine("Hi from IB");
        }
        public void Test() //default implementation
        {
          Console.WriteLine("Hi from Sample");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Sample t = new Sample();
            t.Test(); // "Hi from Sample"
            (IA(t)).Test(); // "Hi from IA"
            (IB(t)).Test(); // "Hi from IB"
            Console.ReadLine();
        }
    }
