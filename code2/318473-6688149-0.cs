     public void DoSomeLongRunningOperation()
     {
        // this is called from the WPF dispatcher thread
        Task.Factory.StartNew(() =>
        {
            // this will execute on a thread pool thread
        })
        .ContinueWith(t =>
        {
            // this will execute back on the WPF dispatcher thread
        },
        TaskScheduler.FromCurrentSynchronizationContext());
     }
