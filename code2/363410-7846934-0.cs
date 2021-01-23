    public static void TraceException(this TraceSource traceSource, Exception ex)
		{
			if (traceSource.Switch.Level == SourceLevels.Verbose ||
				traceSource.Switch.Level == SourceLevels.All)
			{
				traceSource.TraceEvent(TraceEventType.Verbose, 0, ex.ToString());
			}
			else
			{
				traceSource.TraceEvent(TraceEventType.Error, 0,
					" ExceptionType: {0} \r\n ExceptionMessage: {1}", ex.GetType(), ex.Message);
			}
		}
