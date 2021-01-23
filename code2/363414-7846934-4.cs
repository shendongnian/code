    public static void TraceException(this TraceSource traceSource, Exception ex)
    {
        traceSource.TraceException(string.Empty, ex);
    }
    public static void TraceException(this TraceSource traceSource, string comment, Exception ex)
    {
        if (!string.IsNullOrWhiteSpace(comment))
            comment += "\r\n";
        traceSource.TraceEvent(TraceEventType.Error, (int)TraceEventType.Error,
                comment + "ExceptionType: {0} \r\n ExceptionMessage: {1}", ex.GetType(), ex.Message);
        if (traceSource.Switch.Level == SourceLevels.Verbose ||
            traceSource.Switch.Level == SourceLevels.All)
        {
            traceSource.TraceEvent(TraceEventType.Verbose, 0, ex.ToString());
        }
    }
