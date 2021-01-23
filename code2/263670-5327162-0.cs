    System.Threading.ThreadPool.QueueUserWorkItem((WaitCallback)delegate{
        // put long-running code here
        // get the result
        // now use the Dispatcher to invoke code back on the UI thread
        this.Dispatcher.Invoke(DispatcherPriority.Normal,
                 delegate{
                      // this code would be scheduled to run on the UI
                 });
    });
