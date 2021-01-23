    using System;
    using System.Globalization;
    
    public class Test
    {
        static void Main()
        {
            var value = "1110825";
            DateTime dt = DateTime.ParseExact(value, "1yyMMdd",
                                              CultureInfo.InvariantCulture);
            Console.WriteLine(dt);
        }
    }
