    using (var fileStream = File.OpenWrite(theFileName))
    using(var memoryStream = new MemoryStream())
    {
        var formatter = new BinaryFormatter();
    
        formatter.Serialize(memoryStream, customer);
    
        // This resets the memory stream position for the following read operation
        memoryStream.Seek(0, SeekOrigin.Begin);
    
        var bytes = new byte[memoryStream.Length];
        memoryStream.Read(bytes, 0, (int)memoryStream.Length);
    
        // TODO: Encrypt your bytes with your chosen encryption method, and write the result instead of the source bytes
        fileStream.Write(bytes, 0, bytes.Length);
    }
