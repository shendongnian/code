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
            public LogEntry(String line)
            {
                Raw = line;
                Date = ParseDate();
                Type = ParseType();
                Description = ParseDescription();
            }
            public string ParseDescription()
            {
               switch(Type)
               {
                   case LogEntryType.Error:
                       //parse here
                       break;
                   case LogEntryType.Information:
                       //parse here
                       break;
               }
            }
        }
