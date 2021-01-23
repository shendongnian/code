    using System;
    using System.Globalization;
    
    namespace testings
    {
        class Program
        {
            static void Main(string[] args)
            {
                string currency;
                decimal data = 23699.99m;
                currency = string.Format(CultureInfo.CurrentCulture, "{0:£#,0}", data);
                Console.WriteLine(currency);
    
                currency = string.Format(CultureInfo.CurrentCulture, "{0:£#,0.00}", data);
                Console.WriteLine(currency);
    
                currency = string.Format(CultureInfo.CurrentCulture, "{0:£#,0.00}", Math.Floor(data));
                Console.WriteLine(currency);
                Console.ReadKey(false);
            }
        }
    }
