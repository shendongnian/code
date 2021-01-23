    public interface IA
    {
       void Sum();
    }
    public interface IB
    {
        void Sum();
    }
    public class SumC : IA, IB
    {
       void IA.Sum()
        {
            Console.WriteLine("IA");
        }
       void IB.Sum()
       {
           Console.WriteLine("IB");
       }
      public void Sum()
       {
           Console.WriteLine("Default");
       }
    }
    public class MainClass
    {
        static void Main()
        {
            IA objIA = new SumC();
            IB objIB = new SumC();
            SumC objC = new SumC();
            objIA.Sum();
            objIB.Sum();
            objC.Sum();
            Console.ReadLine();
        }
    }
