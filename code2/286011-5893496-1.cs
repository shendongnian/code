    public class NumMaker
    {
      static long num=0;
      public static synchronized next()
      {
        return ++num;
      }
    }
