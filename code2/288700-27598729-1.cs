      private void SendCommand(byte[] data, string ip, int port)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.NoDelay = true;
            var ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            socket.Connect(remoteEP);
            socket.Send(data);
            socket.Close();
        }
