    using System;
    
    class Test
    {
        static void Main()
        {
            Int64 i64 = 0L;
            Console.WriteLine(i64.Equals(0)); // True
            
            object boxed = i64;
            Console.WriteLine(boxed.Equals(0)); // False
            Console.WriteLine(boxed.Equals(0L)); // True        
        }
    }
