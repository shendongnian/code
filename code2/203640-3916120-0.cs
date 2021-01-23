    public struct EventLogLine
    {
        public string EventName { get; private set; }
        public string Message { get; private set; }
        public DateTime Date { get; private set; }
        private static Regex expectedLineFormat = new Regex(
                @"^(?<eventName>[^|]*)\|(?<message>[^|]*)\|(?<date>[^|]*)$",
                RegexOptions.Singleline | RegexOptions.Compiled
        );
        public static EventLogLine Parse(string line) {
            Match match = expectedLineFormat.Match(line);
            if (match.Success) {
                return new EventLogLine {
                    EventName = match.Groups["eventName"].ToString(),
                    Message = match.Groups["message"].ToString(),
                    Date = DateTime.Parse(match.Groups["date"].ToString()
                };
            }
            else {
                throw new ArgumentException("Invalid event log line");
            }
        }
    }
