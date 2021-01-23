    class B : A
    {
      private B(A a)
      {
        //help
        base(a);
      }
      public B GetOneB()
      {
        A a = A.GetOneA();
        return new B(a);
      }
    }
