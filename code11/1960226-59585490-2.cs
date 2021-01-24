    // enable internal logging to the console
    NLog.Common.InternalLogger.LogToConsole = true;
 
    // enable internal logging to a file
    NLog.Common.InternalLogger.LogFile = "c:\\log.txt";
    // enable internal logging to a custom TextWriter
    NLog.Common.InternalLogger.LogWriter = new StringWriter(); //e.g. TextWriter writer = File.CreateText("C:\\perl.txt")
     // set internal log level
    NLog.Common.InternalLogger.LogLevel = LogLevel.Trace;
