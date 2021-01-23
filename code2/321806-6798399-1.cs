    int dataRead = 0;
    
    while ((dataRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
    {
        List<byte> actualBuffer = (new List<byte>(buffer)).GetRange(0, dataRead);
    
        string data = System.Text.Encoding.UTF8.GetString(actualBuffer.ToArray());
        Console.WriteLine("Raw data: {0}", data));
        mainBuffer += data;
        Console.WriteLine(mainBuffer);
    }
