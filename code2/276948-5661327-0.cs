    private string CheckAndReplace(string given, string toAdd)
    {
       Regex regex = new Regex("([A-Z0-9]+_)[0-9]+");
    
       if (regex.IsMatch(given))
       {
          return string.Concat(regex.Match(given).Groups[1].Value, toAdd);
       }
       else 
       {
          ... do something else
       }
    }
