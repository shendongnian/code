    static class MyStaticClass
    {
      static MyStaticClass()
      {
         theTime = new TimeSpan(13, 0, 0);
      }
    
      public static readonly TimeSpan theTime;
      public static bool IsTooLate(DateTime dt)
      {
        return dt.TimeOfDay >= theTime 
      }
    }
