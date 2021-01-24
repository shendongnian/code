        var serverEp = new IPEndPoint(IPAddress.Loopback, 34567);
        var serverSocket = new TcpListener(serverEp);        
        serverSocket.Start(3);
        for (int i = 1; i <= 10; i++)
        {
            var clientSocket = new TcpClient();
            clientSocket.Connect(serverEp);
            Console.WriteLine($"Connected socket {i}");
        }   
