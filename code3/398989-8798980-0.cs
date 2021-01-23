    public class SourceLevelFilter : LogFilter
    {
        private SourceLevels level;
        public SourceLevelFilter(NameValueCollection nvc)
            : base("SourceLevelFilter")
        {
            if (!Enum.TryParse<SourceLevels>(nvc["Level"], out level))
            {
                throw new ArgumentOutOfRangeException(
                    "Value " + nvc["Level"] + " is not a valid SourceLevels value");
            }
        }
        public override bool Filter(LogEntry log)
        {
            if (log == null) throw new ArgumentNullException("log");
            return ShouldLog(log.Severity);
        }
        public bool ShouldLog(TraceEventType eventType)
        {
            return ((((TraceEventType)level) & eventType) != (TraceEventType)0);
        }
        public SourceLevels SourceLevels
        {
            get { return level; }
        }
    }
    // ...
    SourceLevels logLevel = SourceLevels.Warning;
    var builder = new ConfigurationSourceBuilder();
    builder.ConfigureLogging()
        .WithOptions
        .FilterCustom<SourceLevelFilter>("SourceLevelFilter", 
            new NameValueCollection() { { "Level", logLevel.ToString() } } )
        .LogToCategoryNamed("General")
        .WithOptions.SetAsDefaultCategory()
        .SendTo.FlatFile("Main log file")
        .FormatWith(
            new FormatterBuilder()
                .TextFormatterNamed("Text Formatter")
                .UsingTemplate("{timestamp(local:MM/dd/yyyy HH:mm:ss.fff)} [{severity}] {message}"))
        .Filter(logLevel) //Setting the source level filter
        .ToFile("log.txt");
