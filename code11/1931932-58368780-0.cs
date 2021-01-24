    class Program
    {
        static void Main(string[] args)
        {
            MyStaticClass.MyInt = 9017;
            Console.WriteLine("My Int: " + MyStaticClass.MyInt.ToString());
        }
    }
    public static class MyStaticClass
    {
        public static int MyInt { get; set; }
    }
