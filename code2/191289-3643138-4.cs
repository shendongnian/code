    internal class AsyncHelper<T>
    { 
      private readonly Stopwatch timer = new Stopwatch(); 
      private readonly TaskScheduler ui;
      // This should be called from a UI thread.
      internal AsyncHelper()
      {
        this.ui = TaskScheduler.FromCurrentSynchronizationContext();
      }
 
      internal event DownloadCompleteHandler OnOperationComplete; 
      internal Task Start(Func<T> func)
      { 
        timer.Start();
        Task.Factory.StartNew(func).ContinueWith(this.Done, this.ui);
      }
 
      private void Done(Task<T> task) 
      {
        timer.Stop();
        if (task.Exception != null)
        {
          // handle error condition
        }
        else
        {
          InvokeCompleteEventArgs(task.Result); 
        }
      } 
 
      private void InvokeCompleteEventArgs(T result) 
      { 
        var args = new EventArgs(result, null, AsyncMethod.GetEventByClass, timer.Elapsed); 
        if (OnOperationComplete != null) OnOperationComplete(null, args); 
      } 
 
      internal delegate void DownloadCompleteHandler(object sender, EventArgs e); 
    } 
