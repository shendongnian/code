     static class ProxyExtensions
     {
         public static void CleanUp(this IClientChannel proxy)
         {
             try
             {
                 proxy.Close();
             }
             catch
             {
                 proxy.Abort();
                 throw;
             }
         }
     }
