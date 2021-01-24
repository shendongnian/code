    #if DEBUG
         Task.Run(async () =>
         {
             await Task.Delay(500);                   
             GC.Collect();
             GC.WaitForPendingFinalizers();
             GC.Collect();
         });
    #endif
