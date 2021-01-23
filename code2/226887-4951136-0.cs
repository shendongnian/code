    var cancelToken = new CancellationTokenSource();
    var tt = Task.Factory.StartNew(obj =>
                                         {
                                             var tk = (CancellationTokenSource) obj;
                                             while (!tk.IsCancellationRequested)
                                             {
                                                 if (condition)//your condition
                                                 {
                                                     //Do work
                                                 }
                                                 Thread.Sleep(1000);
                                              }
                                          }, cancelToken);
