     public class StaticRandom 
     {
          private static readonly Random _r = new Random();
          private static object _lock = new object();
          public static int Next(int max)
          {
               lock (_lock)
                   return _r.Next(max);
          }
     }
