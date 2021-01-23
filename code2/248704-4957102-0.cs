    using System;
    using System.Globalization;
    using System.Threading;
    
    public class Test
    {
        static void Main()
        {
            String a = "\u00C4";
            String b = "\u0041\u0308";
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK", false);
            Console.WriteLine(a.Equals(b, StringComparison.CurrentCulture));
        }
    }
