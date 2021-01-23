    public class DateList
    {
      private static List<DateTime> mydates = null;  // new List<DateTime>();  haha, oops
    
      public static List<DateTime> Current {
        get {
          if(mydates == null)
          {
            lock(typeof(DateList)) {
              if(mydates == null) {
                mydates = LoadDates();
              }
            }
          }
          return mydates;
        }
      }
    }
