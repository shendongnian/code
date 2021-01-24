    class Program
    {
        static void Main(string[] args)
        {
            Class1.countSAO = 9017;
            Console.WriteLine("1) My Int: " + Class1.countSAO.ToString());
            // or using the function
            Console.WriteLine("2) My Int: " + Class1.MyCountSAOValue().ToString());
        }
    }
    public static class Class1
    {
        public static int countSAO;
        public static int MyCountSAOValue()
        {
            countSAO = 9017;
            return countSAO;
        }
    }
