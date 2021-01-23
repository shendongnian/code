    using System;
    
    class Test
    {
        static void Main()
        {
            decimal d = 1.45m;
            d = Math.Round(d, 1, MidpointRounding.AwayFromZero); // 1.5
            d = Math.Round(d, 0, MidpointRounding.AwayFromZero); // 2
            
            Console.WriteLine(d);
        }
    }
