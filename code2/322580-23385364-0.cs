           try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Bind(new IPEndPoint(IPAddress.Any, 0));
                STUN_Result result = STUN_Client.Query("stunserver.org", 3478, socket);
                Console.WriteLine("Net Type : " + result.NetType.ToString());
                Console.WriteLine("Local IP : " + socket.LocalEndPoint.ToString());
                if (result.NetType != STUN_NetType.UdpBlocked)
                {
                    Console.WriteLine("Public IP : " + result.PublicEndPoint.ToString());
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.StackTrace.ToString());
            }
