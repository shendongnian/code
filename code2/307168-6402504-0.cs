    using System;
    class Test
    {
        static void Main()
        {
            int x = 10;
            Func<int, int> foo = y => y + x;
            Console.WriteLine(foo(x));
        }
    }
