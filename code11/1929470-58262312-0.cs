    static public string RemoveAll(string input)
    {
      string[] prefixes = { "ال", "اَلْ", "الْ", "اَل" };
      foreach (string prefix in prefixes)
        if ( input.StartsWith(prefix) )
          input = input.Substring(prefix.Length);
      return input;
    }
