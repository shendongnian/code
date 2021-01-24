    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(validates|label|name|visibleif)=(""(.+?)"")\s?";
            string input = @"validates=""required positiveInteger"" label=""Enter the Total Value."" name=""totalvalue"" visibleif=""hasvalue:Yes""
    validates=""required positiveInteger"" label=""Enter the Total Value."" name=""totalvalue"" visibleif=""hasvalue:Yes"" fail_attribute=""Undesired""";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
