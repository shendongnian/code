    // Add code to disable UI, if required
    DisableUI();
    // Show the circular progress bar;
    ShowHideCirProgBar(true);
    // Wait till the process ends execution in a background thread
    var task = Task.Factory.StartNew( () =>     
        {
            Process p = Process.Start(longRunningProcess);
            p.WaitForExit();
        });
    // Reenable the UI when the process completes...
    task.ContinueWith( t =>
        {
            EnableUI();
            // hide the circular progress bar
            ShowHideCirProgBar(false);
        }, TaskScheduler.FromCurrentSynchronizationContext());
