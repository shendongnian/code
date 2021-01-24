    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    ...
    void StartLengthyTask() {
        var dlg = CreateWaitDialog();
        dlg.Show();
        // run lengthy task in a background thread
        Task.Run(new Action(BackgroundThread))
            // switch back to UI thread when finished
            .ConfigureAwait(true)
            .GetAwaiter()
            // close the wait dialog
            .OnCompleted(() => dlg.Close());
      // logic here will execute immediately without waiting on the background task
    }
    void BackgroundTask() {
        Thread.Sleep(5000);
    }
