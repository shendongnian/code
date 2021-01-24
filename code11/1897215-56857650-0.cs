    using System;
    using System.Text.RegularExpressions;
    
    class MainClass {
      public static void Main (string[] args) {
        string text = "is, IS";
        string regex = "(?i)is";
        MatchCollection matches = Regex.Matches(text, regex);
        Console.WriteLine("{0} matches found in:\n   {1}", 
                              matches.Count, 
                              text);
      }
    }
