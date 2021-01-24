    using (var client = new TcpClient())
    {
      tcpClient.Connect(myIP, port);
    
      var stream = client.GetStream();
      var buffer = new byte[4096]; // Adapt the size based on what you want to do with the data
      var charBuffer = new char[4096];
      var decoder = Encoding.UTF8.GetDecoder();
    
      int bytesRead;
      while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
      {
        var expectedChars = decoder.GetCharCount(buffer, 0, bytesRead);
        if (charBuffer.Length < expectedChars) charBuffer = new char[expectedChars];
    
        var charCount = decoder.GetChars(buffer, 0, bytesRead, charBuffer, 0);
        Console.Write(new string(charBuffer, 0, charCount));
      }
    
      client.Close();
    }
