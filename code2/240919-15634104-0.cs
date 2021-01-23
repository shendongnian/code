    var mock = new Mock<TraceListener>();
    var ts = new TraceSource("traceSourceName", SourceLevels.Verbose);
    ts.Listeners.Add(mock.Object);
    var message = "the message";
    ts.TraceEvent(TraceEventType.Verbose, 0, message);
    mock.Verify(x => x.TraceEvent(It.IsAny<TraceEventCache>(), "traceSourceName", 
        TraceEventType.Verbose, 0, message), Times.Once(), "Expected a trace");
