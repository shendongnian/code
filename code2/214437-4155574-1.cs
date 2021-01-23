    Dictionary<char, char> replacements = new Dictionary<char, char>();
    ...
    StringBuilder result = new StringBuilder();
    foreach(char c in str)
    {
      char rc;
      if (!_replacements.TryGetValue(c, out rc)
      {
        rc = c;
      }
      result.Append(rc);
    }
