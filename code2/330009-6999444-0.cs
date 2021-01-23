    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            DateTime date = DateTime.Now;
            
            CultureInfo da = new CultureInfo("da");
            // Prints 09-08-2011
            Console.WriteLine(string.Format(da, "{0:dd/MM/yyyy}", date));
            // Prints 09/08/2011
            Console.WriteLine(string.Format(da, "{0:dd'/'MM'/'yyyy}", date));
            // Prints 09/08/2011
            Console.WriteLine(string.Format(da, "{0:dd\\/MM\\/yyyy}", date));
        }
    }
