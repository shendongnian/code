    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            DateTime dt = DateTime.ParseExact("1/1/2011", 
                                              "M/d/yyyy",
                                              CultureInfo.InvariantCulture);
            Console.WriteLine(dt);
        }
    }
