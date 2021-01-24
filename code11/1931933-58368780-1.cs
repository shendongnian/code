    class Program
    {
        static void Main(string[] args)
        {
            MyStaticClass.MyInt = 9017;
            Console.WriteLine("1) My Int: " + MyStaticClass.MyInt.ToString());
            // or using the function
            Console.WriteLine("2) My Int: " + MyStaticClass.MyIntValue().ToString());
        }
    }
    public static class MyStaticClass
    {
        public static int MyInt { get; set; }
        public static int MyIntValue()
        {
            int myIntValue = 9017;
            return myIntValue;
        }
    }
