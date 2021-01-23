    if (System.Threading.Monitor.TryEnter(syncRoot, 1000))
         try
         {
             DoIt();
         }
         finally
         {
             System.Threading.Monitor.Exit(syncRoot);
         }
