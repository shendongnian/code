    private void RunQueuedJobs(object stateInfo)
    {
        using (var scope = Services.CreateScope())
        {
            var autoEvent = (AutoResetEvent)stateInfo;
            var daemonProcessing = scope.ServiceProvider.GetRequiredService<IDaemonService>();
            //daemonProcessing.QueueJob();
             daemonProcessing.RunJob().Wait(); // <-- Here it is
            autoEvent.Set();
        }
    }
