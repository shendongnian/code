    class C
    {
      public void M() {}
    }
    
    class P
    {
        static void Main()
        {
            dynamic d = new C();
            C c = new C();
            Action a1 = c.M; // works
            Action a2 = d.M; // fails at runtime
