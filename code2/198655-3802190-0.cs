    try
    {
      System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("www.google.com",80);
        client.Close();
    }
    catch (SocketException)
    {
      // Offline
    }
