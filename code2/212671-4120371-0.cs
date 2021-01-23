    private LogWriter _logger;
    public void EntLibLogger()
    {
        _logger = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>(); ;
    }
    public void Info(string message)
    {
        LogEntry log = new LogEntry();
        log.Message = message;
        log.Categories.Add("Information");
        log.Priority = Priority.Normal;
        log.Severity = TraceEventType.Information;
        _logger.Write(log);
    }
    public void Warn(string message)
    {
        LogEntry log = new LogEntry();
        log.Message = message;
        log.Categories.Add("Warning");
        log.Priority = Priority.High;
        log.Severity = TraceEventType.Warning;
        _logger.Write(log);
    }
    public void Error(string message, int EventID, Dictionary<String,String> dictMessage)
    {
        LogEntry log = new LogEntry();
        log.Message = message;
        log.Categories.Add("Error");
        log.Priority = Priority.Highest;
        log.Severity = TraceEventType.Error;
        log.EventId = EventID;
        _logger.Write(log, dictMessage);
    }
