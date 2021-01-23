    using (var p = new NamedPipeServerStream("test3", PipeDirection.Out))
    {
        p.WaitForConnection(); 
        Console.WriteLine("Connected!"); 
        using (var writer = new StreamWriter(p))
        {
             writer.WriteLine("Hello!");
             writer.Flush();
        }
        p.WaitForPipeDrain(); 
        p.Close();
    }
