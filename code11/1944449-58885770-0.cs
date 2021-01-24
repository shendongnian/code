    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"([^-\r\n]+-|[^-\r\n]+-[^-\r\n]+-)(\1.*)";
            string input = @"HF-01-HF-01-01
    FBC-FBC-04
    OZYA-03A-OZYA-03A-03
    QC-QC-02
    
    and want them to be returned like so:
    
    HF-01-01
    FBC-04
    OZYA-03A-03
    QC-02";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
