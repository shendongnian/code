    class A 
    {
         private A() { } 
         private static object _Result;
         public static object Result 
         {
             get
             {
                  if (_Result == null)
                       _Result = RunLongOperation();
                  return _Result;
             }
         }
         private static object RunLongOperation(){/* ... */} 
    } 
