    static void Main(string[] args)
    {
        Console.WriteLine("Starting Server");
    
        var pipe = new NamedPipeServerStream("fifoStream.pipe", PipeDirection.InOut);
        Console.WriteLine("Waiting for connection....");
        pipe.WaitForConnection();
    
        Console.WriteLine("Connected");
        pipe.WriteByte(66);
        pipe.Disconnect();
    }
