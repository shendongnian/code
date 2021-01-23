    using System;
    using System.Globalization;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            int x = -10;
            Console.WriteLine(x.ToString());
            
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            // Make a writable clone
            culture = (CultureInfo) culture.Clone();
            culture.NumberFormat.NegativeSign = "!!!";
            
            Thread.CurrentThread.CurrentCulture = culture;
            Console.WriteLine(x.ToString());
        }
    }
