    public static T SafeLimex<T>(Func<T> F, int Timeout, out bool Completed)   
       {
           var iar = F.BeginInvoke(null, new object());
           if (iar.AsyncWaitHandle.WaitOne(Timeout))
           {
               Completed = true;
               return F.EndInvoke(iar);
           }
             F.EndInvoke(iar); //not calling EndInvoke will result in a memory leak
             Completed = false;
           return default(T);
       } 
