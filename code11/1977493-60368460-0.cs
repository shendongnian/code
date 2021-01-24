    Struct C1
    {
      public int v1;
    }
    
    Class C2 
    {
      public C2()
      {
        var c1 = new C1();
        //  You must ensure to mark it as ref when passing it as argument
        //  This enforces you are aware that the function may mess with your variable
        DoSomethingWithC1(ref c1);
        //  c1.v1 is changed after function call
        Console.WriteLine(c1.v1.toString());
      }
      //  Define at function signature that it must pass a reference
      //  If you don't mark it as a reference a new variable is created (see Flydog57 answer)
      void DoSomethingWithC1(ref C1 c1)
      {
        //Here c1 is a reference, you are actually manipulating the same c1 as in C2 constructor
        c1.v1 = 33;
      }
    }
