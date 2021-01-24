        class foo
        {
            public static int A = foo.B;
            public static int B = 3;
            public static int C = foo.B;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(foo.A);
            Console.WriteLine(foo.B);
            Console.WriteLine(foo.C);
            Console.ReadLine();
        }
