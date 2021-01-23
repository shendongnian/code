    public IEnumerable<Frob> GetFrobs(FrobFactory f, int count)
    {
        for (int i = 0; i < count; ++i)
          yield return f.MakeFrob();
    }
    ...
    FrobFactory factory = whatever;
    IEnumerable<Frobs> frobs = GetFrobs();
    ...
    foreach(Frob frob in frobs) { ... }
