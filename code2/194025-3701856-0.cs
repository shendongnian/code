    // Get the stream
    NetworkStream stream = client.GetStream();
    Byte[] data = new Byte[256];
    
    // String to store the response ASCII representation.
    String responseData = String.Empty;
    
    // Read the first batch of the TcpServer response bytes.
    int bytes = stream.Read(data, 0, data.Length);
    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
