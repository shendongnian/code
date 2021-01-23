    public MyEnum Field  // added for convenience
    { 
      get { return (MyEnum)Interlocked.CompareExchange(ref _field, 0, 0); }
      set { Interlocked.Exchange(ref _field, (int)value); }
    }  
