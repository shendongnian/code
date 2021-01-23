     CancellationTokenSource cts = new CancellationTokenSource();
     var processingTask = Task.Factory.StartNew(() =>
        {
              foreach(var item in StuffToProcess())
              {
                   cts.Token.ThrowIfCancellationRequested();
 
                   // Do your processing in a loop
              }
        });
      var cancelTask = Task.Factory.StartNew(() =>
          {
               Thread.Sleep(/* The time you want to allow before cancelling your processing */);
               cts.Cancel();
          });
       try
       {
           Task.WaitAll(processingTask, cancelTask);
       }
       catch(AggregateException ae)
       {
           ae.Flatten().Handle(x =>
              {
                   if(x is OperationCanceledException)
                   {
                       // Do Anything you need to do when the task was canceled.
                       return true;
                   }
                   // return false on any unhandled exceptions, true for handled ones
              });
       }
