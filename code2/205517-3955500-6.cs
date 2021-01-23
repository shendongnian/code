    class A
    {
      public A()
      {
      }
      public B B
      {
        get
        {
          if(b == null)
            b = new B();
          return b;
        }
      }
      private B b;
    }
    class B
    {
      public B()
      {
      }
      public A A
      {
        get
        {
          if(a == null)
            a = new A();
          return a;
        }
      }
      private A a;
    }
    // ...
    A obj = new A(); // new B doesn't get called yet
    obj.B.Something(); // ... Now it does...
