    class Program
    {
        public delegate double MethodDelegate( double a );
        static void Main()
        {
            var delList = new List<MethodDelegate> {Foo, FooBar};
            Console.WriteLine(delList[0](12.34));
            Console.WriteLine(delList[1](16.34));
            Console.ReadLine();
        }
        private static double Foo(double a)
        {
            return Math.Round(a);
        }
        private static double FooBar(double a)
        {
            return Math.Round(a);
        }
    }
