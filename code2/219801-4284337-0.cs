    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            DisplayMatch("ID P20101125_0003 -- Pendiente de autorización --");
            // No match due to _
            DisplayMatch("ID_P20101125_0003 any text any text");
        }
    
        static readonly Regex Pattern = new Regex
            ("^" + // Start of string
             "ID " +
             "(" + // Start of capturing group
             "P" +
             "(20[0-9][0-9])" + // yyyy
             "(0[1-9]|1[012])" + // MM
             "(0[1-9]|[12][0-9]|3[01])" + // dd
             @"_\d{4}" +
             ")" // End of capturing group
             );
        
        static void DisplayMatch(string input)
        {
            Match match = Pattern.Match(input);
            if (match.Success)
            {
                Console.WriteLine("Matched: {0}", match.Groups[1]);
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
