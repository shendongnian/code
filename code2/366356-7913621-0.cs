    using System;
    using System.Globalization;
    
    class Test
    {    
        static void Main(string[] args)
        {
            string text = "11/23/2011 23:59:59 UTC +0800";
            string pattern = "MM/dd/yyyy HH:mm:ss 'UTC' zzz";
            
            DateTimeOffset dto = DateTimeOffset.ParseExact
                (text, pattern, CultureInfo.InvariantCulture);
            Console.WriteLine(dto);
        }
    }
