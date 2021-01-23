    private void HandleClientComm(object client)
    {
        TcpClient tcpClient = (TcpClient)client;
        NetworkStream clientStream = tcpClient.GetStream();
        int size = 1;
        byte[] message = new byte[1];
        int bytesRead;
        while (true)
        {
            bytesRead = 0;
            if (clientStream.DataAvailable)
                bytesRead = clientStream.Read(message, 0, 1);
            if (bytesRead > 0)
            {
                OnRecived(new RecivedArgs("tick", null));
            }
            Thread.Sleep(1);
        }
    }
