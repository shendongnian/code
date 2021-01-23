    using System;
    using System.Text.RegularExpressions;
    
    public static class Splitter
    {
      private static Regex regex;
      
      static Splitter()
      {
        string alphaNumeric = "[a-zA-Z]";
        string notAlphaNumeric = "[^a-zA-Z]";
        string pattern = "^(?<left>" + notAlphaNumeric + "+)(?<right>" + alphaNumeric + notAlphaNumeric + "+)$";
        regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.ExplicitCapture);
      }
      
      public static bool Split(string input, out string left, out string right)
      {
        var match = regex.Match(input);
        if (match.Success && match.Groups["left"].Captures.Count == 1 && match.Groups["right"].Captures.Count == 1)
        {
          left = match.Groups["left"].Captures[0].Value;
          right = match.Groups["right"].Captures[0].Value;
          return true;
        }
        else
        {
          left = null;
          right = null;
          return false;
        }
      }
    }
    
    public static class Program
    {
      public static void Test(string input)
      {
        string left, right;
        if (Splitter.Split(input, out left, out right))
          Console.WriteLine("\"" + input + "\" -> \"" + left + "\" + \"" + right + "\"");
        else
          Console.WriteLine("The string \"" + input + "\" could not be split");
      }
    
      public static void Main()
      {
        Test("2510");
        Test("2510|");
        Test("|2510");
        Test("25I10");
      }
    }
