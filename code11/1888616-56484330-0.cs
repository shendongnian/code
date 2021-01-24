    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"UseProp1|(\(?Prop1\?Prop1(:Test)\)):(\(UseProp2\?Prop2):\((Test\sText):\s+'\{(.+?)}'\s+Test\sReference:\{(.+?)}\)\)";
            string input = @"UseProp1
    (Prop1?Prop1:Test):(UseProp2?Prop2:(Test Text: '{TextProperty}' Test Reference:{Reference}))
    ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
