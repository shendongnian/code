        static int x = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(x); // before call foo->0
            foo();
            Console.WriteLine(x); // after call foo -> 10
            Console.ReadKey();
        }
        public static void foo()
        {
            x = 10;
        }
