    // DO THIS
    public IEnumerable<Frob> GetFrobs(FrobFactory f, int count)
    {
        // No yields in a public method that throws!
        if (f == null) 
          throw new ArgumentNullException("f", "factory must not be null");
        return GetFrobsForReal(f, count);
    }
    private IEnumerable<Frob> GetFrobsForReal(FrobFactory f, int count)
    {
        // Yields in a private method
        Debug.Assert(f != null);
        for (int i = 0; i < count; ++i)
          yield return f.MakeFrob();
    }
