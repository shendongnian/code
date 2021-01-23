    string BuildNextName(string originalName)
    {
      string name = originalName;
      while( Exists(name) || deletedNames.Contains(name))
      {
        name = Increment(name);
      }
      return name;
    }
