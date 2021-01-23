    using System.Diagnostics;
    using System.Linq;
    EventLog events = new EventLog("Application", System.Environment.MachineName);
    foreach (EventLogEntry entry in  events.Entries.Cast<EventLogEntry>().Reverse())
    {
        //Do your tasks
    }
