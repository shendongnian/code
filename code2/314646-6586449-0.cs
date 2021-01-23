    using System;
    using System.Text.RegularExpressions;
    
    public class FadelMS
    {
       public static void Main()
       {
          string input = "The quick \b brown fox\b0 jumps over the \b lazy dog\b0.";
          string pattern = "\\b0";
          string replacement = "<\\b>";
          Regex rgx = new Regex(pattern);
          string temp = rgx.Replace(input, replacement);
    
          pattern = "\\b";
          replacement = "<b>";
          Regex rgx = new Regex(pattern);
          string result = rgx.Replace(temp, replacement);
   
       }
    }
