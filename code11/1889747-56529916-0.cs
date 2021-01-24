    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"<span id=[""'](ctl00_.+|other_ids)[""']>(.+?)<\/span>";
            string input = @"<span id=""ctl00_BodyContentPlaceHolder_lblDescription"">Random Description</span>
    <span id='ctl00_BodyContentPlaceHolder_lblDescription'>Random Description</span>
    ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
