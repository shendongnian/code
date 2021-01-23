    byte[] message = new byte[1024];
    using (MemoryStream memoryStream = new MemoryStream(message, true))
    {
        using (StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.ASCII))
        {
            var lineToAdd = "Hello World!";
            while (memoryStream.Length - memoryStream.Position > lineToAdd.Length)
            {
                streamWriter.WriteLine(lineToAdd);
                streamWriter.Flush();
            }
        }
    }
