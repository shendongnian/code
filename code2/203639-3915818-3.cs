    public struct EventLogLine {
        public string EventName { get; private set; }
        public string Message { get; private set; }
        public DateTime Date { get; private set; }
        public static EventLogLine Parse(string line) {
            var splitline = line.Split('|');
            if(splitline.Length != 3) throw new ArgumentException("Invalid event log line");
            return new EventLogLine { 
                EventName = splitline[0],
                Message = splitline[1],
                Date = DateTime.Parse(splitline[2]),
            };
        }
    }
