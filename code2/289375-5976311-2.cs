    interface I
    {
      int M();
    }
    class A : I
    {
      int I.M() { return CallM(); }
      protected int CallM() { return 1; }
    }
    class B : A, I
    {
      int I.M() { return CallM(); }
    }
