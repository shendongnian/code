    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    var localMyObject = this.myObject;
    Task.Factory.StartNew(() =>
    {
      // Run asynchronously on a ThreadPool thread.
      Thread.Sleep(1000); // TODO: review if you *really* need this   
      return DoTheCodeThatNeedsToRunAsynchronously();   
    }).ContinueWith(task =>
    {
      // Run on the UI thread when the ThreadPool thread returns a result.
      if (task.IsFaulted)
      {
        // Do some error handling with task.Exception
      }
      else
      {
        localMyObject.ChangeSomeProperty(task.Result);
      }
    }, ui);
