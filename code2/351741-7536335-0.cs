    static void Main(string[] args)
    {
        Action clientCode = () =>
            {
                var buffer = new byte[100];
                var clientSocket = new Socket(AddressFamily.InterNetwork,
                                              SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(IPAddress.Loopback, 6690);
                clientSocket.Send(buffer);
                clientSocket.Disconnect(false);
                Console.WriteLine("Client: message sent and socket disconnected.");
                while (true) {
                    var bytesRead = clientSocket.Receive(buffer);
                    if (bytesRead == 0) {
                        break;
                    }
                    Console.WriteLine("Client: read " + bytesRead + " bytes.");
                }
                clientSocket.Dispose();
            };
        var server = new TcpListener(IPAddress.Loopback, 6690);
        var thread = new Thread(new ThreadStart(clientCode));
        server.Start();
        thread.Start();
        var client = server.AcceptTcpClient();
        using(NetworkStream stream = client.GetStream()) {
            using(StreamReader streamReader = new StreamReader(stream))
            {
                var data = streamReader.ReadToEnd();
                Console.WriteLine("Server: read " + data.Length + " bytes.");
                // Since we 're here we know that the client has disconnected.
                // Send the response before StreamReader is disposed, because
                // that will cause the socket itself to be closed as well!
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("Server: sending response.");
                stream.Write(new byte[10], 0, 10);
                Console.WriteLine("Server: closing socket.");
            }
        }
        server.Stop();
        Console.WriteLine("Server: waiting for client thread to complete.");
        thread.Join();
        return;
    }
