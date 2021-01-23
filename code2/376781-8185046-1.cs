     public class X
     {
          private readonly Object _lock = new Object();
          // ...
                lock (_lock)
                {
                }
