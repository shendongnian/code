    private void Window_Closing(object sender, CancelEventArgs e)
    {
        #region Comments
        // In case an offline export is still unfinished, cancel its Task.     
        // Otherwise an exception is raised for terminating it improperly.
        //
        // This is tricky because: 
        // * The task cancellation happens when the window is being closed, 
        //   i.e., when this method is called.
        // * Closure of the window must be prevented until OfflineExportTask has 
        //   completed its cancellation.
        // * After its cancellation is complete, then this window must close, 
        //   which terminates the application.
        // 
        // To accomplish this behavior:
        // * OfflineExportTask is tested to see if it is still in progress when 
        //   this method is called:
        //   > If OfflineExportTask is null, an offline export was never 
        //     started.
        //   > If OfflineExportTask's status is RanToCompletion, it's done so 
        //     doesn't need to be cancelled.
        //   > If OfflineExportTask's status is Canceled, it doesn't need to be     
        //     cancelled again. See the explanation below for this condition.
        // * If OfflineExportTask needs to be cancelled:
        //   > It is cancelled by calling Cts.Cancel()
        //   > The closure of the window is prevented with the code 
        //     e.Cancel = true
        //   > This method is exited.
        // * To get the window to close once cancellation is complete:
        //   > Waiting for cancellation is accomplished by using ContinueWith, 
        //     which starts a new task the moment OfflineExportTask is complete 
        //     (i.e., its cancellation is complete).
        //   > The new ContinueWith task executes only one line of code: Close()
        //   > The ContinueWith statement specifies 
        //     TaskScheduler.FromCurrentSynchronizationContext(), which is 
        //     necessary since the Close() call must happen on the GUI thread.
        //   > Executing ContinueWith's Close() code causes this method, 
        //     Window_Closing, to be called a second time. 
        //   > When this method is called the second time, OfflineExportTask's 
        //     status is TaskStatus.Canceled, which is why the "if" statement 
        //     tests for this condition.
        //   > When this method is called the second time, none of the code 
        //     within the "if" block is executed and the window closes normally.
        // 
        // Note that the following code was attempted, which specifies 
        // ContinueWith with the starting of the OfflineExportTask:
        // 
        // OfflineExportTask = Task.Factory.StartNew(()=>
        //    MemberService.ExportForOfflineMode(Cts.Token),
        //    Cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default)
        //    .ContinueWith(t => Close(), CancellationToken.None, 
        //    TaskContinuationOptions.OnlyOnCanceled,
        //    TaskScheduler.FromCurrentSynchronizationContext());
        // 
        // This did not work for this scenario, as OfflineTaskExport's status is 
        // still Running the second time this Window_Closing method gets called. 
        // Additionally, even when this was tested for, the window still didn't     
        // close.
        #endregion
        if (OfflineExportTask != null
            && OfflineExportTask.Status != TaskStatus.RanToCompletion
            && OfflineExportTask.Status != TaskStatus.Canceled
            && OfflineExportTask.Status != TaskStatus.Faulted)
        {
            // Establish task that will run the moment the OfflineExportTask's 
            // cancellation is complete. All it does is close the application, 
            // i.e., call this method again.
            OfflineExportTask.ContinueWith((antecedent) => Close(),
                TaskScheduler.FromCurrentSynchronizationContext());
            // Cancel the OfflineExportTask.
            Cts.Cancel();
            // Prevent the window from closing.
            e.Cancel = true;
            // BusyIndicator is a Telerik WPF control, not germane to this
            // topic. Serves as an example of how a progress indicator can
            // be used.
            BusyIndicator.BusyContent = "Canceling export. Please wait... ";
            BusyIndicator.IsBusy = true;
            return;
        }
        // This code is an example of something that should be executed only
        // when the window is actually closing.
        // Save the window's current position and size to restore these settings 
        // the next time the application runs. 
        Settings.Default.StartLeft = Left;
        Settings.Default.StartTop = Top;
        Settings.Default.StartWidth = Width;
        Settings.Default.StartHeight = Height;
        Settings.Default.Save();
    }
