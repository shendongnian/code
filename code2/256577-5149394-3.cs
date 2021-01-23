    class B : A
    {
      //help
      private B(A a) : base(a)
      {
      }
      public B GetOneB()
      {
        A a = A.GetOneA();
        return new B(a);
      }
    }
