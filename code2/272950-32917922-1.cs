    try
    {
        OfflineExportTask = Task.Factory.StartNew(() => 
            MemberService.ExportForOfflineMode(Cts.Token),
            Cts.Token, TaskCreationOptions.LongRunning,    
            TaskScheduler.Default);
        // The task must be awaited in order to catch any exceptions.
        await OfflineExportTask;
    }
    catch (OperationCanceledException ex)
    {
        // Do nothing. The application is closing while the task 
        // was still in progress.
    }
    catch (Exception ex)
    {
        // Regular exception handling code
    }
