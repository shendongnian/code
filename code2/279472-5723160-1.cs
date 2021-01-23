    var s = new Socket(SocketType.Dgram, ProtocolType.Udp);
    s.Bind(localEP);
    var e = new SocketAsyncEventArgs();
    e.Completed += OnReceive;
    e.RemoteEndPoint = new IPEndPoint(IPAddress.IPv6Any, 0);
    e.SetBuffer(new byte[BufferSize], 0, BufferSize);
    if (!s.ReceiveFromAsync(e)) OnReceive(s, e);
