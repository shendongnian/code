    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?:SOYAD\s*|ADI\s*|BABA\sADI\s*)(\S+)";
            string input = @"TÜRKIYE CUMHURIYETI
    NÜFUS CÜZDANI
    CUMHURYETI TURKIYE CUMHURIYE
    H12
    SERTTURKIYE CUMHURIYETI 1
    11111111111
    HKIYE CUMHURIY
    URI YETI TURKIYE CUMH
    T.C. KIMLIK NO.
    SOYAD
    DEMIRAL
    ADI
    SERHAT
    BABA ADI
    BILAL
    ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
