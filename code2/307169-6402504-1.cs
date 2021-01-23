    using System;
    class Test
    {
        static void Main()
        {
            ExtraClass extra = new ExtraClass();
            extra.x = 10;
        
            Func<int, int> foo = extra.DelegateMethod;
            Console.WriteLine(foo(x));
        }
        private class ExtraClass
        {
            public int x;
            public int DelegateMethod(int y)
            {
                return y + x;
            }
        }
    }
