    using (var fileStream = System.IO.File.OpenRead(path))
    {
        // seek to starting point
        fileStream.Seek(977, SeekOrigin.Begin);
        
        // read 200 bytes
        var buffer = new byte[200];
        fileStream.Read(buffer, 0, 200);
    }
