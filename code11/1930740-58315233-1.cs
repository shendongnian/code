    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^Name:\s*(\S+)\s*$";
            string input = @"Name: John
    Name: Jane  
    Name: Mary 
    
    a sentence here with name in it would be fine. ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
