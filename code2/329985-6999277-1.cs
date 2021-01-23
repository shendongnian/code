    Trace.Listeners.Add(new ConsoleTraceListener());
    Trace.Listeners.Add(new DefaultTraceListener{LogFileName="C:\temp\myOutput.txt"});
    ...       
    Trace.Flush();
    Trace.Listeners.Clear();
