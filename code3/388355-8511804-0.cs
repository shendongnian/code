     public static string GetNumberFromStrFaster(string str)
        {
          str = str.Trim();
          Match m = new Regex(@"^[\+\-]?\d*\.?[Ee]?[\+\-]?\d*$",         
          RegexOptions.Compiled).Match(str);
          return (m.Value);
        }
