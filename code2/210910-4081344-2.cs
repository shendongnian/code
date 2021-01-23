    // Compile and run with: mcs so_regex.cs && mono so_regex.exe
    using System;
    using System.Text.RegularExpressions;
    
    public class SORegex {
      public static void Main() {
        string[] values = {"[123].[ABC]", "[123 456].[ABC]", "[123.ABC", "ABC", "[ABC]", "[ABC["};
        string[] expected = {"fail", "fail", "match", "match", "match", "fail"};
        string pattern = @"(?<!\[[\d ]+\]\.\[?)ABC\]?";  // Don't force [ to match ].
        //string pattern = @"(?:(?<!\[[\d ]+\]\.\[)ABC\]|(?<!\[[\d ]+\]\.)(?<!\[)ABC(?!\]))";  // Force balanced brackets.
        Console.WriteLine("pattern: {0}", pattern);
        int i = 0;
        foreach (string text in values) {
          Match m = Regex.Match(text, pattern);
          bool isMatch = m.Success;
          Console.WriteLine("{0}: {1} (expected: {2})", text, isMatch? "match" : "fail", expected[i++]);
          if (isMatch) Console.WriteLine("\tmatched: {0}", m.Value);
        }
      }
    }
