            var cts = new CancellationTokenSource();
            var newTask = Task.Factory.StartNew(state =>
                                       {
                                          var tcts = (CancellationTokenSource)state;
                                          while (!tcts.IsCancellationRequested)
                                          {
                                          }
                                       }, cts, cts.Token);
            if (!newTask.Wait(3000, cts.Token)) cts.Cancel();
