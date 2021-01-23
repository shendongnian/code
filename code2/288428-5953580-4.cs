    private int? _age;
    public int Age
    {
      get { return _age.GetValueOrDefault(-1); }
      set { _age = value; }
    }
    public bool HasAge { get { return _age.HasValue; } }
