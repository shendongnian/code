    var queue = new BlockingCollection<string>();
    var cts = new CancellationTokenSource();
    TaskScheduler ui = TaskScheduler.FromCurrentSynchronizationContext();
    var task1 = new Task(
      () =>
      {
        for (int i = 0; i < 10; i++)
        {
          token.ThrowIfCancellationRequested();
          string code = i.ToString() + "\t" + AsyncHttpReq.get_source_WebRequest(uri);
          queue.Add(code);
        }
      });
      task1.ContinueWith(
        antecedents =>
        {
          if (token.IsCancellationRequested)
          {
            TxtBlock2.Text = "Task cancel detected";
          }
          else
          {
            TxtBlock2.Text = "Signalling production end";
          }
          queue.CompleteAdding();
        }, ui);
      var taskCP = new Task(
        () =>
        {
          while (!queue.IsCompleted)
          {
            string dlCode;
            if (queue.TryTake(out dlCode))
            {
              Dispatcher.Invoke(() =>
              {
                TxtBlock3.Text = dlCode; 
              }
            }
          }
        });
      task1.Start();
      taskCP.Start();
