    using System;
    
    class Test
    {    
        static void Main()
        {
            decimal d = 1234.5678m;
            Console.WriteLine("Before: {0}", d); // Prints 1234.5678
            d = decimal.Round(d, 2);
            Console.WriteLine("After: {0}", d); // Prints 1234.57
        }
    }
