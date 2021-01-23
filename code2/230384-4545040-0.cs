    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            string text = "January 1, 2008";
            
            DateTime dt = DateTime.ParseExact(text, "MMMM d, yyyy",
                                              CultureInfo.InvariantCulture);
            Console.WriteLine(dt);
        }
    }
