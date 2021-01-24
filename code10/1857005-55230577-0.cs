    Something like this:
    ```c#
    public class LogResultTarget : NLog.Targets.Target
    {
        public Result CurrentTargetResult { get; } = new Result();
        protected override void Write(NLog.LogEventInfo logEvent)
        {
            //Convert NLog logEvent to LogMessage
            LogLevel level = (LogLevel)Enum.Parse(typeof(LogLevel), logEvent.Level.Name);
            LogMessage lm = new LogMessage(logEvent.TimeStamp.ToUniversalTime(), level, logEvent.Message);
            CurrentTargetResult.LogMessages.Add(lm);
        }
        protected override void Write(NLog.Common.AsyncLogEventInfo logEvent)
        {
            Write(logEvent.LogEvent);
        }
    }
    ```
