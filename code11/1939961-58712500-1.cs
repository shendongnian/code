    var monitor = context.Storage.GetMonitoringApi();
    var jobDetails = monitor.JobDetails(context.BackgroundJob.Id);
    foreach (var kvp in jobDetails.Properties)
    {
        Trace.WriteLine($"{kvp.Key => kvp.Value}");
    }
    foreach (var entry in jobDetails.History.OrderBy(e => e.CreatedAt))
    {
        Trace.WriteLine($"{entry.StateName} ({entry.CreatedAt}): {Reason}");
        foreach (var kvp in entry.Data)
        {
            Trace.WriteLine($"   {kvp.Key} => {kvp.Value}");
        }
    }
