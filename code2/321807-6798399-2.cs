    //of course the problem has noting to do with the string being volatile...
    private volatile string mainBuffer = string.Empty;
    
    byte[] buffer = new byte[1024];
        
    while (networkStream.Read(buffer, 0, buffer.Length) > 0)
    {
        string data = System.Text.Encoding.UTF8.GetString(buffer);
        Console.WriteLine("Raw data: {0}", data));
        mainBuffer += data;
        Console.WriteLine(mainBuffer);
    }
