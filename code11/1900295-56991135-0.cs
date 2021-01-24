    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\B(room)\B|\b(room)\b|(room)";
            string input = @"Meeting.Room
    MeetingRoom21
    Room
    Meeting2Room
    Meeting.room
    12MeetingRoom110.MeetingRoom";
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
