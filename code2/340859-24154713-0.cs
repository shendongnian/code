        private static void UDPListener()
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(11000))
                {
                    string loggingEvent = "";
                    while (true)
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any source.
                        var receivedResults = await udpClient.ReceiveAsync();
                        loggingEvent += Encoding.ASCII.GetString(receivedResults.Buffer);
                    }
                }
            });
        }
