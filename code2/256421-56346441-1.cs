    static void StartListner(IPAddress sourceIp, IPAddress multicastGroupIp, IPAddress localIp, int port)
    {
        Task.Run(() =>
        {
            try
            {
                Console.WriteLine("Starting: "  + sourceIp + " - " + multicastGroupIp + " - " + localIp + " / " + port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localEndpoint = new IPEndPoint(localIp, port);
                socket.Bind(localEndpoint);
                byte[] membershipAddresses = new byte[12]; // 3 IPs * 4 bytes (IPv4)
                Buffer.BlockCopy(multicastGroupIp.GetAddressBytes(), 0, membershipAddresses, 0, 4);
                Buffer.BlockCopy(sourceIp.GetAddressBytes(), 0, membershipAddresses, 4, 4);
                Buffer.BlockCopy(localIp.GetAddressBytes(), 0, membershipAddresses, 8, 4);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddSourceMembership, membershipAddresses);
                while (true)
                {
                    byte[] b = new byte[1024];
                    int length = socket.Receive(b);
                    Console.WriteLine("PORT: " + port + " : " + Encoding.ASCII.GetString(b, 0, length));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        });
    }
