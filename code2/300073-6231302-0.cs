    static class MyStaticClass
    {
      public static readonly TimeSpan theTime = new TimeSpan(13, 0, 0);
      public static bool IsTooLate(DateTime dt)
      {
        return dt.TimeOfDay >= theTime;
      }
    }
 
