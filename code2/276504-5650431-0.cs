    private void DoWork()
    {
        // Executed on a separate thread via Thread/BackgroundWorker/Task
        // Dispatcher.Invoke executes the delegate on the UI thread
        Dispatcher.Invoke(new System.Action(() => SetDatesource(myDatasource)));
    }
