    class X
    {
      int a;
      public X(int b)
      {
        this.a = b; // this stands for "this object"
        // a = b is absolutely the same
      }
      public X getItsThis()
      {
        return this;
      }
    }
    X x = new X();
    X x2 = x.getItsThis();
    // x and x2 refer to THE SAME object
    // there's still only one object of class X, but 2 references: x and x2
