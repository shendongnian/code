    public class LogsSink : ILogEventSink
    {
        /// <summary>
        /// Format of the output log
        /// </summary>
        readonly string Format = "{0} {1} {2}";
        /// <summary>
        /// Emit the provided log event to the sink.
        /// </summary>
        /// <param name="logEvent">The log event to write</param>
        public void Emit(LogEvent logEvent)
        {
            var t = logEvent.Timestamp;
            LogMsg msg = new LogMsg()
            {
                Text = logEvent.RenderMessage(),
                Lvl = LevelToSeverity(logEvent),
                TimeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + " -" + t.Offset.ToString(@"hh\:mm"),
            };
            if (LogsViewModel.logFile != null)
                LogsViewModel.logFile.AllText.Add(string.Format(Format, msg.TimeStamp, msg.Lvl, msg.Text));
            LogsViewModel.logFile.AppendText();
        }
        static string LevelToSeverity(LogEvent logEvent)
        {
            switch (logEvent.Level)
            {
                case LogEventLevel.Debug:
                    return "[DBG]";
                case LogEventLevel.Error:
                    MainPageViewModel.statusBar.AddError();
                    return "[ERR]";
                case LogEventLevel.Fatal:
                    return "[FTL]";
                case LogEventLevel.Verbose:
                    return "VERBOSE";
                case LogEventLevel.Warning:
                    MainPageViewModel.statusBar.AddWarning();
                    return "WARNING";
                default:
                    return "[INF]";
            }
        }
    }
    struct LogMsg
    {
        public string Lvl;
        public string Text;
        public string TimeStamp;
    }
Register your sink when you instantiate the logger
public LogsSink sink;
sink = new LogsSink();
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Sink(sink)
                .CreateLogger();
Let me know if you have any questions!
