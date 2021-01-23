    public class DateList
    {
      private static List<DateTime> mydates = new List<DateTime();
    
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
