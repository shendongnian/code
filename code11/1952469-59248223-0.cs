      using System.Text.RegularExpressions;
      ... 
      string source = "TEST^S CHECK по-русски (in RUSSIAN) it's a check! a.b.c.d";
      string result = Regex.Replace(source, @"\p{L}[\p{L}\^'\.]*",
        match => match.Value.Substring(0, 1).ToUpper() + match.Value.Substring(1).ToLower());
      Console.Write(result);
