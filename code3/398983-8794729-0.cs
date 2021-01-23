    // Note: my system is in en-gb
    using System;
    
    class Test
    {
        static void Main()
        {
            decimal x = 6.0m;
            decimal y = 5.50m;
            decimal z = x * y;
            Console.WriteLine(z); // Prints 33.000
            Console.WriteLine(z.ToString("0.00")); // Prints 33.00
            // Same with composite formatting
            Console.WriteLine("{0:0.00}", z); // Still prints 33.00
            // If you want fewer than 2 decimal digits when they're
            // not necessary
            Console.WriteLine(z.ToString("0.##")); // Prints 33
        }
    }
