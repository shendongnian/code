    private static void beginReceive(Socket clientSocket)
    {
        byte[] buffer = new byte[1000];
        clientSocket.BeginReceive(
               buffer, 0, 1000, SocketFlags.None, OnReceiveData, clientSocket);
    }
