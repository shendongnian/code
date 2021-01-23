            string traceFileLocation = "yourFileName";
            TraceSource traceSource;
            TextWriterTraceListener traceListener;
            traceFileLocation = traceFileLocation;
            traceSource = new TraceSource("your source name");
            traceListener = new TextWriterTraceListener(traceFileLocation);
            traceListener.TraceOutputOptions = TraceOptions.LogicalOperationStack | 
                                                TraceOptions.DateTime | 
                                                TraceOptions.Timestamp | 
                                                TraceOptions.ProcessId | 
                                                TraceOptions.ThreadId;
            traceSource.Switch = new SourceSwitch("someName","some Name");
            traceSource.Switch.Level = SourceLevels.Information;
            traceSource.Listeners.Clear();
            traceSource.Listeners.Add(traceListener);
            Trace.AutoFlush = true;
            Trace.CorrelationManager.StartLogicalOperation("logical operation");
            traceSource.TraceEvent(TraceEventType.Error, (int)TraceEventType.Error, "messsage");
            Trace.CorrelationManager.StopLogicalOperation();
