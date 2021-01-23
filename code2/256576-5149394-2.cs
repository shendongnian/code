    class A
    {
      protected DateTime P { get; private set; }
      protected A(A copy){
          //copy all properties
          this.P = A.P;
      }
      protected A()
      {
        P = DateTime.Now;
      }
      protected A GetOneA()
      {
        return new A();
      }
