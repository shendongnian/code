    // version 2
    class B 
    {
      public void M(int x, int y) { Console.WriteLine(1); }
      public void M(int x, short y) { Console.WriteLine(2); }
    }
    class D : B  { }
    ...
    new D().M(1, 1); // 1
