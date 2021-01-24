    IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.
                          FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
    Server grpcServer = new Server
    {
        Services = { Simulator.BindService(new Service()) },
        Ports = { new ServerPort(ipAddress.ToString(), 8080, ServerCredentials.Insecure) }
    };
    grpcServer.Start();
    Task.Run(() =>
    {
        while (true)
        {
            UdpClient udpServer = new UdpClient(8888);
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] clientRequestData = udpServer.Receive(ref clientEndPoint);
            string clientRequest = Encoding.ASCII.GetString(clientRequestData);
            Console.WriteLine($"Recived {clientRequest} from {clientEndPoint.Address}");
            byte[] responseData = Encoding.ASCII.GetBytes("Response");
            udpServer.Send(responseData, responseData.Length, clientEndPoint);
            udpServer.Close();
        }
    });
