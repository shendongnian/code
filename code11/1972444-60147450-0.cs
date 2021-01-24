    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
          string input = "This is   text with   far  too   much   white space."
          // NOTE: REPLACE the pattern with the one you need
          string pattern = "\\s+";
          string replacement = " ";
          string result = Regex.Replace(input, pattern, replacement);
          
          Console.WriteLine("Original String: {0}", input);
          Console.WriteLine("Replacement String: {0}", result);                             
       }
    }
