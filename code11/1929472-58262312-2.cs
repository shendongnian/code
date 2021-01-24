    static public string RemoveAl(string input)
    {
      string[] prefixes = { "ال", "اَلْ", "الْ", "اَل" };
      foreach (string prefix in prefixes)
        if ( input.StartsWith(prefix) )
        {
          input = input.Substring(prefix.Length);
          break;
        }
      return input;
    }
