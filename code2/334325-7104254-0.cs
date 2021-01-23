    using (var myFile = File.Create("TestFile.txt"))
    {
        var myTextListener = new TextWriterTraceListener(myFile);
        Trace.Listeners.Add(myTextListener);
        Trace.Write("Test output ");                
    }
