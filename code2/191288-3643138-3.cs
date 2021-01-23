    private Task StartBackgroundTask<T>(Func<T> action)
    {
      var ui = TaskScheduler.FromCurrentSynchronizationContext();
      var task = Task.Factory.StartNew(action)
          .ContinueWith(task =>
          {
            if (task.Exception != null)
              ; // handle error
            else
              use task.Result; // handle success
          }, ui);
    }
