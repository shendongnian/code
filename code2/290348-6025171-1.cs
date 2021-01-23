            string returnData;
            byte[] receiveBytes;
            //ConsoleKeyInfo cki = new ConsoleKeyInfo();
            using (UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3800)))
            {
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3800);
                while (true)
                {
                    receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                    returnData = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine(returnData);
                }
            }
