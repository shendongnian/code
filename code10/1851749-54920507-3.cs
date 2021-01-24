    using System;
    
    class Test
    {
        static void Main()
        {
            double? x = 8.39;
            double? y = -0.49;
            
            // Your expression
            Console.WriteLine(x ?? 0 + y ?? 0);
            
            // The equivalent you're expecting
            Console.WriteLine((x ?? 0) + (y ?? 0));
            
            // The actual bracketing
            Console.WriteLine(x ?? ((0 + y) ?? 0));
        }
    }
