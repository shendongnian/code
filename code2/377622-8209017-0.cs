    Task parent = new Task(() =>
      {
        var cts = new CancellationTokenSource();
        var tf = new TaskFactory<Int32>(cts.Token,
                                        TaskCreationOptions.AttachedToParent,
                                        TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        var childTasks = new[] {
            tf.StartNew(() => StartService1()),
            tf.StartNew(() => StartService2()),
            tf.StartNew(() => StartService3()),
            tf.StartNew( () => StartService4()),
            tf.StartNew( () => StartService5())
         };
      });
      parent.ContinueWith(p =>
      {
       //(..do something..)
      }, TaskContinuationOptions.None);
      parent.Start();
