    // Detect if client disconnected
    if (tcp.Client.Poll(0, SelectMode.SelectRead))
    {
      byte[] buff = new byte[1];
      if (tcp.Client.Receive(buff, SocketFlags.Peek) == 0)
      {
        // Client disconnected
        bClosed = true;
      }
    }
