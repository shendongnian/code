	// Set log file name.
	string AppLogFileName = "MyLogFile"; // Retrieve from GetTextReportFileName(...)
	ThreadContext.Properties["ReportName"] = AppLogFileName;
	// Set up Log4net.
	ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());
	XmlConfigurator.Configure(repository);
    // Log a message.
	var logger = LogManager.GetLogger("ReportLogger");
	logger.Info("Hello world");
