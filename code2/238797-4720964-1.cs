    public static T SafeLimex<T>(Func<T> F, int Timeout, out bool Completed)   
       {
           var iar = F.BeginInvoke(null, new object());
           if (iar.AsyncWaitHandle.WaitOne(Timeout))
           {
               Completed = true;
               return F.EndInvoke(iar);
           }
             F.EndInvoke(iar);
             Completed = false;
           return default(T);
       } 
