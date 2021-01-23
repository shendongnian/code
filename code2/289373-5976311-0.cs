    interface I
    {
      int M();
    }
    class A : I
    {
      int I.M() { return 1; }
      protected int CallM() { return (this as I).M(); }
    }
    class B : A, I
    {
      int I.M() { return CallM(i); }
    }
