    DateTime yesterday = DateTime.Now.AddDays(-1);
    int count = 0;
    using (Eventlog appLog = new EventLog("System"))
    {
        count = appLog.Entries.OfType<EventLogEntry>().Count(
            e.Source.Equals("USER32", StringComparison.CurrentCultureIgnoreCase) && 
            e.TimeGenerated > yesterday
        )
    }
