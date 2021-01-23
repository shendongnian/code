    class A
    {
      private int foo;
      public int Foo { get { return foo; } }
      public A(int x)
      {
          foo = x;
          OpenConnectionOrSomething();
      }
    }
    class B:A
    {
      public B(int x) : base(x)
      {
          // can't initialize foo here: it's private
          // only the base class knows how to do that
      }
      // this property uses the Foo property initialized in the base class 
      public int TripleOfFoo { get { return 3*Foo; } }
    }
