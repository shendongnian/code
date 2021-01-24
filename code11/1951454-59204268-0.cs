    public class Receiver
    {
        private readonly UdpClient udp;
        private IPEndPoint ip = new IPEndPoint(IPAddress.Any, 1740);
        public Receiver()
        {
            udp = new UdpClient
            {
                ExclusiveAddressUse = false
            };
            udp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udp.Client.Bind(ip);
        }
        public void StartListening()
        {
            udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            var bytes = udp.EndReceive(ar, ref ip);
            StartListening();
        }
    }
