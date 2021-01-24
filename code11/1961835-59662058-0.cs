      using System.Text.RegularExpressions;
      ...
      string demo = "abc%x20def%20pqr";
      string result = Regex.Replace(
          demo, 
        "%x?([0-9A-F]{2})", 
          m => ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(), 
          RegexOptions.IgnoreCase);
      Console.Write(result);
