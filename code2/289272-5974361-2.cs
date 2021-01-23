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
      // thanks to Porges - if you're using .NET 4 then this is cleaner and achieves the same result:
      private static Lazy<List<DateTime>> mydates2 = new Lazy<List<DateTime>>(() => LoadDates(), true);
      public static List<DateTime> Current2
      {
         return mydates2.Value;
      }
    }
