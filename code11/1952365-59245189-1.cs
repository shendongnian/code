    public static SlowRandom
    {
      private static readonly syncObject = new object();
      private static readonly Random generator = new Random();
      public static int Next()
      {
        lock (syncObject) return generator.Next();
      }
    }
