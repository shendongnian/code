                //client
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[1];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(remoteEP);
                //Server
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, port);
                TcpListener listener = new TcpListener(localEP);
                listener.Start();
