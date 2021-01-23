    class A
    {
      public A(B b)
      {
        this.B = b;
      }
      public B B;
    }
    class B
    {
      public B(A a)
      {
        this.A = a;
      }
      public A A;
    }
    // ...
    A someA = new A(
      new B(
        null)); // You have to break the cycle somewhere..
    someA.B.A = someA;
