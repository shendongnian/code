     enum OnError
     {
         Throw,
         DontThrow
     }
     static class ProxyExtensions
     {
         public static void CleanUp(this IClientChannel proxy, OnError errorBehavior)
         {
             try
             {
                 proxy.Close();
             }
             catch
             {
                 proxy.Abort();
                 if (errorBehavior == OnError.Throw)
                 {
                     throw;
                 }
             }
         }
     }
