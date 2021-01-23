    public static void MethodOne()
    {
      lock (lockObj)
      {
        MethodTwo();
      }
    }
    private static void MethodTwo()
    {
      //This method can be called multiple times
      //without going past MethodOne and so you only
      //lock once
    }
    private static void MethodThree()
    {
    }
