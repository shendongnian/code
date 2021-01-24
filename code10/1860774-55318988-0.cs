public class Test{
   private DateTime Time {get;set;}
   public object TimeSinceEpoch {
      get{
         return Time
      }
      set{
         DateTime x = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
         Time = x.AddMilliseconds(Convert.ToDouble(value));
      }
   }
}
