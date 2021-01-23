    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            var match = Regex.Match("abc", "(.*)");
            while (match.Success)
            {
                Console.WriteLine(match.Length);
                match = match.NextMatch();
            }
        }
    }
