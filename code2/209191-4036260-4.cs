    var cts = new CancellationTokenSource();
    var newTask = Task.Factory.StartNew(state =>
                               {
                                  var token = (CancellationToken)state;
                                  while (!token.IsCancellationRequested)
                                  {
                                  }
                                  token.ThrowIfCancellationRequested();
                               }, cts.Token, cts.Token);
    if (!newTask.Wait(3000, cts.Token)) cts.Cancel();
