    class A
    {
        public int B {get;set;}
    }
    void ReassignA(A a)
    {
      Console.WriteLine(a.B);
      a = new A {B = 2};
      Console.WriteLine(a.B);
    }
    // ...
    A a = new A { B = 1 };
    ReassignA(a);
    Console.WriteLine(a.B);
