    // DON'T DO THIS
    public IEnumerable<Frob> GetFrobs(FrobFactory f, int count)
    {
        if (f == null) 
          throw new ArgumentNullException("f", "factory must not be null");
        for (int i = 0; i < count; ++i)
          yield return f.MakeFrob();
    }
