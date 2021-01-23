    using System;
    enum Test { a1, a2, a3, a4 }
    class Program
    {
        static void Main(string[] args)
        {
            Test a = Test.a2;
            Console.WriteLine((a > Test.a1));
            Console.WriteLine((a > Test.a2));
            Console.WriteLine((a > Test.a3));
            Console.WriteLine((a > Test.a4));
            Console.ReadKey();
        }
    }
