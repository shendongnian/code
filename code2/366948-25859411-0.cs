    TextWriterTraceListener[] listeners = new TextWriterTraceListener[] {
    new TextWriterTraceListener("C:\\debug.txt"),
    new TextWriterTraceListener(Console.Out)
    };
    
    Debug.Listeners.AddRange(listeners);
    
    Debug.WriteLine("Some Value", "Some Category");
    Debug.WriteLine("Some Other Value");
