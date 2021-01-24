    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(\b[0-9a-f]{8}\b-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-\b[0-9a-f]{12}\b)\s+(.*?)\s+[A-Z](https?:\/\/\S+)\s+(.*)$";
            string input = @"1cb07348-34a4-4741-b50f-c41e584370f7 TeamSpeak Addon Author Vhttps://badges-content.teamspeak.com/1cb07348-34a4-4741-b50f-c41e584370f7/addon_author Creator of TeamSpeak Addons";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
