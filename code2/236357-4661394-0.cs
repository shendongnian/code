    using System;
    
    class Test
    {
        static void Main()
        {
            TestChange<int>();
            TestChange<float>();
            TestChange<decimal>();
        }
        
        static void TestChange<T>()
        {
            byte b = 10;
            T t = (T) Convert.ChangeType(b, typeof(T));
            Console.WriteLine("10 as a {0}: {1}", typeof(T), t);
        }
    }
