    string response = "Hello";
    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
    if (ipAddress != null)
    {
        IPEndPoint serverEndPoint = new IPEndPoint(ipAddress, 25);
        byte[] receiveBuffer = new byte[100];
        try
        {
            using (TcpClient client = new TcpClient(serverEndPoint))
            {
                using (Socket socket = client.Client)
                {
                    socket.Connect(serverEndPoint);
                    byte[] data = Encoding.ASCII.GetBytes(response);
                    socket.Send(data, data.Length, SocketFlags.None);
                    socket.Receive(receiveBuffer);
                    Console.WriteLine(Encoding.ASCII.GetString(receiveBuffer));
                }
            }
        }
        catch (SocketException socketException)
        {
            Console.WriteLine("Socket Exception : ", socketException.Message);
            throw;
        }
    }
