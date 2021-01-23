    struct Foo
    {
       public int Bar { get; private set; }
       public int Baz { get; private set; }
    
       public Foo(int bar, int baz) : this() 
       {
           Bar = bar;
           Baz = baz;
       }
    }
    
    ...
    
    Foo[] foos = new Foo[] { new Foo(1,2), new Foo(3,4) };
