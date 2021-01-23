    public class Instrument
    {
      Object lockKey = new Object();
      public double Measure() 
      { 
        lock(lockKey)
        {
          return 0; 
        }
      }
    }
