    class A
    {
      public A()
      {
        this.B = new B();
      }
      public B B;
    }
    class B
    {
      public A A = new A(); // This is the same as instantiating the object in the ctor
    }
