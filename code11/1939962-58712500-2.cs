    var monitor = context.Storage.GetMonitoringApi();
    var jobDetails = monitor.JobDetails(context.BackgroundJob.Id);
                
    if(jobDetails.Properties.TryGetValue("RecurringJobId", out string recurringId))
    {
        var values = context.Connection.GetAllEntriesFromHash($"recurring-job:{recurringId}");
        foreach (var kvp in values)
        {
            Trace.WriteLine($"{kvp.Key} => {kvp.Value}");
        }
    }
