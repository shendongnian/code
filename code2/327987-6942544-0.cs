    public bool Excluded(Type t)
    {
      foreach(var type in _excludeExceptions)
      {
        if(type.Equals(t))
          return true;
      }
    }
