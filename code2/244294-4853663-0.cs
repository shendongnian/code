    using System.Net.Sockets;
    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
    s.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.1"), 0)); // use your local IP
    byte[] incoming = BitConverter.GetBytes(1);
    byte[] outgoing = BitConverter.GetBytes(1);
    s.IOControl(IOControlCode.ReceiveAll, incoming, outgoing);
    s.ReceiveBufferSize = 8 * 1024 * 1024;  // 8MB
