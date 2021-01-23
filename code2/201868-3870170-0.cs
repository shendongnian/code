    using System;
    using System.Globalization;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            decimal d = 5.50m;
            string withComma = d.ToString();
            string withDot = d.ToString(CultureInfo.InvariantCulture);
            Console.WriteLine(withComma);
            Console.WriteLine(withDot);
        }
    }
