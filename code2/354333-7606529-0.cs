    public string MyDebugFoo { get; set; }
    public string MyOtherFoo { get; set; }
    public string Foo {
    #if DEBUG
      get { return MyDebugFoo; } }
      set { MyDebugFoo = value; } }        
    #else
      get { return MyOtherFoo; } }
      set { MyOtherFoo = value; } }
    #endif 
    }
