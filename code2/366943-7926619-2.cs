    // Set up listener
    string filename = @"C:\listener.txt";
    FileStream traceLog = new FileStream(filename, FileMode.OpenOrCreate);
    TextWriterTraceListener listener = new TextWriterTraceListener(traceLog);
    // Output to listener
    listener.WriteLine("Trace message here");
    // Flush any open output before termination.
    // Maybe in an override of Form.OnClosed.
    listener.Flush();
