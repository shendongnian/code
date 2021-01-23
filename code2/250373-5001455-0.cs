    class A{
      public int Test(){ return 1; }
    }
    class B : A{
      public new int Test(){ return 2; }
    }
    B b = new B();
    Console.WriteLine( b.Test() );
    A b2 = new B();
    Console.WriteLine( b2.Test() );
