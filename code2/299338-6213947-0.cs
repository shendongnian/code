    DateTime yesterday = DateTime.Now.Subtract(new TimeSpan(24, 0, 0));
    using (EventLog appLog = new EventLog("System"))
    {
        long count = appLog.Entries.OfType<EventLogEntry>().Where(
            e => (e.TimeGenerated > yesterday) && 
                 (e.Source.ToUpperInvariant == "USER32").LongCount();
