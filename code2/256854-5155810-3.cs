        public enum LogEntryType
        {
            Error = -1,
            Information = 0,
        }
        public class LogEntry
        {
            public string Raw;
            public DateTime Date;
            public LogEntryType Type;
            public string Description;
            public InnerLogEntry InnerEntry;
            public LogEntry(String line)
            {
                Raw = line;
                Date = ParseDate();
                Type = ParseType();
                //parse the 'raw' description...
                Description = ParseDescription();
                //determine the inner entry type...
                switch (Type)
                {
                    case LogEntryType.Error:
                        InnerEntry = new ErrorLogEntry(this);
                        break;
                    case LogEntryType.Information:
                        InnerEntry = new InformationLogEntry(this);
                        break;
                }                
            }
        }
        public abstract class InnerLogEntry
        {
            protected LogEntry Parent;
            public InnerLogEntry(LogEntry logEntry)
            {
                Parent = logEntry;
            }
        }
        public class InformationLogEntry : InnerLogEntry
        {
            public InformationLogEntry(LogEntry logEntry)
                : base(logEntry)
            {
                //parse custom data
            }
        }
        public class ErrorLogEntry : InnerLogEntry
        {
            public ErrorLogEntry(LogEntry logEntry)
                : base(logEntry)
            {
                //parse custom data
            }
        }
