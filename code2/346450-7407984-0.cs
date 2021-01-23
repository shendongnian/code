    if (EventLog.Exists("System"))
    {
        var log = new EventLog("System", Environment.MachineName, "EventLog");
        var entries = new EventLogEntry[log.Entries.Count];
        log.Entries.CopyTo(entries, 0);
        var startupTimes = entries.Where(x => x.InstanceId == 2147489653).Select(x => x.TimeGenerated);
        var shutdownTimes = entries.Where(x => x.InstanceId == 2147489654).Select(x => x.TimeGenerated);
    }
