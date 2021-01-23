    using System;
    using System.Text.RegularExpressions;
     
    class Program
    {
      static void Main()
      {
        string input = "foo \"some \\\" text\" bar";
     
        Match match = Regex.Match(input, @"""[^""\\\r\n]*(?:\\.[^""\\\r\n]*)*""");
     
        if (match.Success)
        {
          Console.WriteLine(input);
          Console.WriteLine(match.Groups[0].Value);
        }
      }
    }
