    public class BaseClass
    {
        public static int Max { get { return 0; } }
    }
    public class InteriorClass : BaseClass
    {
    }
    public class DerivedClass : InteriorClass
    {
        public new static int Max { get { return BaseClass.Max + 1; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BaseClass.Max = {0}", BaseClass.Max);
            Console.WriteLine("InteriorClass.Max = {0}", InteriorClass.Max);
            Console.WriteLine("DerivedClass.Max = {0}", DerivedClass.Max);
            Console.ReadKey();
        }
    }
