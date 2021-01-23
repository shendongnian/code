    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main(string[] arg)
        {
            Regex regex = new Regex(@"###E(-?\d+) ?$");        
            string text = "###E123 ";
            
            Match match = regex.Match(text);
            if (match.Success)
            {
                string group = match.Groups[1].Value;
                int parsed = int.Parse(group);
                Console.WriteLine(parsed);
            }
        }
    }
