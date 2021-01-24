csharp
private static void ConnectToServer()
    {
        int attempts = 0;
        // Add a null check
        while (_clientSocket == null || !_clientSocket.Connected)
        {
            try
            {
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress remoteIPAddress = IPAddress.Parse(serverAddress);
                IPEndPoint remoteEndPoint = new IPEndPoint(remoteIPAddress, serverPort);
                _clientSocket.Connect(remoteEndPoint);
                attempts++;
            }
            catch (SocketException)
            {
                Debug.Log("Connection attempts: " + attempts.ToString());
            }
        }
        Debug.Log("Connected!");
        isConnected = true;
    }
