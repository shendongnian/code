        new Thread(() =>
        {
           Dispatcher.CurrentDispatcher.UnhandledExceptionFilter += Dispatcher_UnhandledExceptionFilter;
           Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(delegate
           {
               doer();
           }));
        }).Start();
