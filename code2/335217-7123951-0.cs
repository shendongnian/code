    public class LogWriter
    {
        public static Log(string log, string source, string message, EventLogEntryType type, int eventid)
        {
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, log);
				
                EventLog.WriteEntry(source, message, type, eventid);
        }
    }
