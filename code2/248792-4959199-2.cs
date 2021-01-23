    public string Foo
    {
      get { return foo; }
      set 
      {
        foo = value;         
        Validation();
      }
    }
