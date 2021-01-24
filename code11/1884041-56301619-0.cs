    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(.+?)(.txt)$";
            string input = @"C:/..../email_4.txt
    C:/..../email_7.txt
    C:/..../email_8.txt
    C:/..../email_9.txt";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
