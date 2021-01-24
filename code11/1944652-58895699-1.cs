    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?is)\w*(\w)(?= (\1)\w*)";
            string input = @"word dark king glow we end hello bye low wing
    word Dark King Glow We End hello bye LoW wing";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
