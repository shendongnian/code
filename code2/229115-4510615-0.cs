    // Start by making it visible, this can be done on the UI thread.
    pb_elvisSherlock.Visible = true;
    
    // Now grab the task scheduler from the UI thread.
    var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    // Now create a task that runs on a background thread to wait for 3 seconds.
    Task.Factory.StartNew(() =>
    {
        Thread.Sleep(3000);
    // Then, when this task is completed, we continue...
    }).ContinueWith((t) =>
    {
        //... and hide your picture box.
        pb_elvisSherlock.Visible = false;
    // By passing in the UI scheduler we got at the beginning, this hiding is done back on the UI thread.
    }, uiScheduler);
