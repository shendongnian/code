    internal class CurrentTimeGetter    
    {        
      private static int lastTicks = -1;        
      private static DateTime lastDateTime = DateTime.MinValue;        
      /// <summary>        
      /// Gets the current time in an optimized fashion.        
      /// </summary>        
      /// <value>Current time.</value>        
      public static DateTime Now        
      {            
        get            
        {                
          int tickCount = Environment.TickCount;                
          if (tickCount == lastTicks)                
          {                    
            return lastDateTime;                
          }                
          DateTime dt = DateTime.Now;                
          lastTicks = tickCount;                
          lastDateTime = dt;                
          return dt;            
        }        
      }    
    }
    // It would be used like this:
    DateTime timeToLog = CurrentTimeGetter.Now;
