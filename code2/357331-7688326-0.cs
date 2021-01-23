    using System;
    using System.Data.SqlTypes;
    
    class Test
    {
        static void Main()
        {
            DateTime dt = (DateTime) SqlDateTime.MinValue;
            Console.WriteLine(dt);
        }
    }
