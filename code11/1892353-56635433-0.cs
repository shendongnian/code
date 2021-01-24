    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"([A-Z0-9]{4})";
            string input = @" ;   Message Number
        ;   |         Time Offset (ms)
        ;   |         |        Type
        ;   |         |        |        ID (hex)
        ;   |         |        |        |     Data Length
        ;   |         |        |        |     |   Data Bytes (hex) ...
        ;   |         |        |        |     |   |
        ;---+--   ----+----  --+--  ----+---  +  -+ -- -- -- -- -- -- --
             1)         2.0  Rx         0400  8  01 5A 01 57 01 D2 A6 02 
             2)         8.6  Rx         0500  8  02 C1 02 C9 02 BE 02 C2 
             3)        36.2  Rx         0401  8  01 58 01 59 01 01 01 01 
             4)        41.7  Rx         01C4  8  27 9C 64 8C 00 03 E8 08 
             5)        43.1  Rx         0501  8  02 C0 02 C1 02 C6 02 C0 
             6)        62.7  Rx         01C2  8  27 9C 60 90 00 0F 04 08 ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
