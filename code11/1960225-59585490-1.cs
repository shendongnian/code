    // enable internal logging to the console
    InternalLogger.LogToConsole = true;
 
    // enable internal logging to a file
    InternalLogger.LogFile = "c:\\log.txt";
    // enable internal logging to a custom TextWriter
    InternalLogger.LogWriter = new StringWriter(); //e.g. TextWriter writer = File.CreateText("C:\\perl.txt")
 
    // set internal log level
    InternalLogger.LogLevel = LogLevel.Trace;
