    private static void SendAndReceive()
    {
      IPEndPoint ep1 = new IPEndPoint(IPAddress.Any, 1234);
      ThreadPool.QueueUserWorkItem(delegate
      {
        UdpClient receiveClient = new UdpClient();
        receiveClient.ExclusiveAddressUse = false;
        receiveClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        receiveClient.Client.Bind(ep1);
        byte[] buffer = receiveClient.Receive(ref ep1);
      });
    
      UdpClient sendClient = new UdpClient();
      sendClient.ExclusiveAddressUse = false;
      sendClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
      IPEndPoint ep2 = new IPEndPoint(IPAddress.Parse("X.Y.Z.W"), 1234);
      sendClient.Client.Bind(ep1);
      sendClient.Send(new byte[] { ... }, sizeOfBuffer, ep2);
    }
