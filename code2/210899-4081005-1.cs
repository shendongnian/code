    mock.Setup(foo => foo.Submit(IsLarge())).Throws<ArgumentException>();
    ...
    public string IsLarge() 
    { 
      return Match<string>.Create(s => !String.IsNullOrEmpty(s) && s.Length > 100);
    }
