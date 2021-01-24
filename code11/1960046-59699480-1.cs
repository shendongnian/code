        private static Socket _sock;
        private static IPEndPoint _endPoint;
        public StartSerialPortListenerThread()
        {
            // This socket is used to send Write request to thread in C dll
            _sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr = IPAddress.Parse("127.0.0.1");
            _endPoint = new IPEndPoint(serverAddr, 5555);
            
            // This starts the listener thread in the C dll
            Task.Factory.StartNew(() =>
            {
                ConnectToSerialPort(TelnetCallback, StatusCallback, ErrorCallback);
            });
        }
