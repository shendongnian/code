    TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
    Debug.Listeners.Add(tr1);
            
    TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("Output.txt"));
    Debug.Listeners.Add(tr2);
