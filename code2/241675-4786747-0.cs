    using System;
    using System.Numerics;
    
    class Test
    {
        static void Display(decimal d)
        {
            d = d.Normalize(); // Using extension method from other post
            Console.WriteLine(d);
        }
        
        static void Main(string[] args)
        {
            Display(123.4567890000m); // Prints 123.456789
            Display(123.100m);        // Prints 123.1
            Display(123.000m);        // Prints 123
            Display(123.4567891234m); // Prints 123.4567891234
        }
    }
