    public bool IsWarningEnabled
    {
        get
        {
            return writer.GetFilter<SourceLevelFilter>().ShouldLog(TraceEventType.Warning);
        }
    }
