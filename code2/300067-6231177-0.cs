    class FooProxy
    {
      Foo bar; // internal object
      
      public string Baz 
      {
        get {return bar.Baz; } 
        set { bar.Baz = value }
      }
    
      public bool Oink
      {
        get {return bar.Oink.Enabled; } 
        set {bar.Oink.Enabled = value; }
      }
    }
