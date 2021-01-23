    // First, check if event log contains required source
    if(EventLog.SourceExists("YourSourceName"))
    {
        // Specify your source name and log name (e.g. Application, System or some custom name)
        EventLog log = new EventLog()
        {
            Source = "YourSourceName",
            Log = "Application"
        };
    
        // Enumerate through log entries
        foreach (EventLogEntry entry in log.Entries)
        {
            // Do something with log entries
            Console.WriteLine(entry.Message);
        }
    
         // You also may filter log entries by date (LINQ is used for this)
         foreach (EventLogEntry entry in log.Entries.Cast<EventLogEntry>().Where(x => (DateTime.Now - x.TimeGenerated).Days == 0))
        {
            // Do something with log entries
            Console.WriteLine(entry.Message);
        }
    }
