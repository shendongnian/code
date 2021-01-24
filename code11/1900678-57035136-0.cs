    private void ProcessLog(LogEntry log, TraceEventCache traceEventCache)
        {
            // revert any outstanding impersonation
            //using (RevertExistingImpersonation())
            //{
                var items = new ContextItems();
                items.ProcessContextItems(log);
                var matchingTraceSources = GetMatchingTraceSources(log);
                var traceListenerFilter = new TraceListenerFilter();
                foreach (LogSource traceSource in matchingTraceSources)
                {
                    traceSource.TraceData(log.Severity, log.EventId, log, traceListenerFilter, traceEventCache, ReportExceptionDuringTracing);
                }
            //}
        }
