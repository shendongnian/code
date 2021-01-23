    public class Widget
    {
      private static rngInstance = new Random() ;
      
      public bool IsPiratePrincess()
      {
        bool isTrue = rngInstance.Next(1, 5000) == 1 ;
        return isTrue ;
      }
    
    }
