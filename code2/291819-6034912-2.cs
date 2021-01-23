    class A
    {
       public Foo { get; set; }
       public Bar { get; set; }
       public Level { get; set;}
    }
    
    class B
    {
      private A _internalA;
    
      public Foo { get { return _internalA.Foo; }  set { _internalA.Foo = value; } }
      public Bar { get { return _internalA.Bar; }  set { _internalA.Bar= value; } }
      public Points { get { return _internalA.Level; }  set { _internalA.Level = value; } }
    }
