    static void Main(string[] args)
    {
        Console.WriteLine("Starting Client");
        var pipe = new NamedPipeClientStream(".", "fifoStream.pipe", PipeDirection.InOut, PipeOptions.None);
        Console.WriteLine("Connecting");
        pipe.Connect();
        pipe.ReadByte(); //here I receive byte 66
        Console.WriteLine("Done");
    }
