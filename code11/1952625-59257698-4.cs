    // version 1
    class B 
    {
      public void M(int x, int y) { Console.WriteLine(1); }
    }
    class D : B 
    {
      public void M(int x, short y) { Console.WriteLine(2); }
    }
    ...
    new D().M(1, 1); // 2
