    public class Test_MockSocket : Socket
    {
        public Test_MockSocket() : base (
                        (new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000)).AddressFamily,
                        (SocketType.Stream),
                        (ProtocolType.Tcp))
        {
        }
    }
