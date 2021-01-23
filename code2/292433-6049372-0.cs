    if (System.Threading.Monitor.TryEnter(syncRoot, 1000))
         try
         {
             ....
         }
         finally
         {
             System.Threading.Monitor.Exit(syncRoot);
         }
