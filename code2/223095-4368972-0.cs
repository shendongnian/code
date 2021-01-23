    FileStream stream = new FileStream(@"c:\temp\build.txt", 
        FileMode.Open, FileAccess.Read);
    
    stream.Seek(-1024, SeekOrigin.End);     // rewind enough for > 1 line
    
    StreamReader reader = new StreamReader(stream);
    reader.ReadLine();      // discard partial line
    
    while (!reader.EndOfStream)
    {
        string nextLine = reader.ReadLine();
        Console.WriteLine(nextLine);
    }
