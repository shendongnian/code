    class Program
    {
      private static int _i;
      static void Main()
      {
        _i = 0;
        Add(100);
        // now _i == 100
      } 
      static void Add(int increment)
      {
        _i += 100;
      }
    }
