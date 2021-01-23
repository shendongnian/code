    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            CultureInfo us = new CultureInfo("en-US");
            for (int i = 0; i < 65536; i++)
            {
                char c = (char) i;
                string s = c.ToString();
                if (s.ToUpperInvariant() != s.ToUpper(us))
                {
                    Console.WriteLine(i.ToString("x4"));
                }
            }
        }    
    }
