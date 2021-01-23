    public static Stream Foo()
    {
        var memStream = new MemoryStream();
        var streamWriter = new StreamWriter(memStream);
    
        for (int i = 0; i < 6; i++)
            streamWriter.WriteLine("TEST");
    
        streamWriter.Flush();                                   <-- need this
        memStream.Seek(0, SeekOrigin.Begin);
        return memStream;
    }
