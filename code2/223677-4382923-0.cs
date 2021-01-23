    public class SystemClock
    {
      private DateTime _start;
      
      public Int32 SystemTime
      {
        get
        {
          return Convert.ToInt32(Math.Floor(DateTime.Now.Subtract(this._start).TotalSeconds));
        }
      }
      
      public SystemClock()
      {
        this._start = DateTime.Now;
      }
    }
