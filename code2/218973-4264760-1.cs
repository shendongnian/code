    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            decimal d = decimal.Parse("1200.00", CultureInfo.InvariantCulture);
            Console.WriteLine(d.ToString(CultureInfo.InvariantCulture));
        }
    }
