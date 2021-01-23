    using System;
    using System.Text.RegularExpressions;
    
    public class Test 
    {
        public static void Main()
        {
            string test = "one [two] three [four] five";
            Regex regex = new Regex(@"(?<text>[a-z]+)|(?<bracketed>\[[a-z]+\])");
            
            Match match = regex.Match(test);
            while (match.Success)
            {
                Console.WriteLine("text: {0}; bracketed: {1}",
                                  match.Groups["text"],
                                  match.Groups["bracketed"]);
                match = match.NextMatch();
            }
        }
    }
