    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
    IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 8221);
    sock.Bind(ipe);
    sock.Listen(4);
    Socket c = sock.Accept(); // added
    while (true) {
        if (!c.Connected) continue;
        byte[] buffer = new byte[1024];
        if (c.Receive(buffer) > 0) Console.WriteLine(Encoding.UTF32.GetString(buffer));
    }
