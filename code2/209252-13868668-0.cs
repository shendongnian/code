        const int iPort = 7611;
        const int IP_TIMEOUT = 1000;
        private static List<DiscoveryServer> FindIPAddresses(string filter, bool justFindOne)
        {
            List<DiscoveryServer> ipNames = new List<DiscoveryServer>();
            byte[] message = new byte[2] { 17, 2 };
            string hostname = Dns.GetHostName();
            IPHostEntry entry = Dns.GetHostEntry(hostname);
            List<UdpClient> clients = new List<UdpClient>();
            try
            {
                // send out UDP packets on all IPv4 interfaces.
                foreach (var ipAddress in entry.AddressList)
                {
                    if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, iPort);
                        UdpClient udpC = new UdpClient(ipLocalEndPoint);
                        clients.Add(udpC);
                        udpC.EnableBroadcast = true;
                        udpC.Client.ReceiveTimeout = IP_TIMEOUT;
                        int response1 = udpC.Send(message, 2, new IPEndPoint(IPAddress.Broadcast, iPort));
                    }
                }
                if (clients.Count == 0)
                {
                    throw new Exception("There are no IPv4 network interfaces available");
                }
                System.DateTime startTime = System.DateTime.Now;
                double timeout = IP_TIMEOUT / 1000;
                IPEndPoint remEP = new IPEndPoint(IPAddress.Broadcast, iPort);
                while (System.DateTime.Now.Subtract(startTime) < TimeSpan.FromSeconds(timeout) &&
                    !(justFindOne && ipNames.Count() > 0))
                {
                    foreach (var udpC in clients)
                    {
                        if (udpC.Available > 0)
                        {
                            byte[] response = udpC.Receive(ref remEP);
                            string name;
                            if (response.Length > 2)
                            {
                                name = System.Text.Encoding.ASCII.GetString(response, 3, response[2]);
                                if (filter == "" || name.Contains(filter))
                                {
                                    DiscoveryServer ds = new DiscoveryServer(name, remEP.Address);
                                    ipNames.Add(ds);
                                    if (justFindOne) break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                foreach (var udpC in clients)
                {
                    udpC.Close();
                }
            }
            return ipNames;
        }
