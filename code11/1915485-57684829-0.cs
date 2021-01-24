    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^\D:(\\\w+\\\w+(\\?))$";
            string input = @"C:\folder1\folder2
    C:\folder1\folder2\
    C:\folder1\folder2\file1.txt
    C:\folder1\folder2\file2.docx
    
    ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
