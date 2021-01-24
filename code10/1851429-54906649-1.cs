      using System.Text.RegularExpressions;
      ...
      string source = "ABBBACCADBCAADA";
      // Any symbol followed by itself should be replaced with the symbol and 'x'
      string result = Regex.Replace(source, @"(.)(?=\1)", "$1x");
      Console.Write(result);
