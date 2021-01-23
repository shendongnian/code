        private static void UDPListener()
        {
            Task.Run(() =>
            {
                using (var udpClient = new UdpClient(11000))
                {
                    string loggingEvent = "";
                    while (true)
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any source.
                        var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        var receivedResults = udpClient.Receive(ref remoteEndPoint);
                        loggingEvent += Encoding.ASCII.GetString(receivedResults);
                    }
                }
            });
        }
