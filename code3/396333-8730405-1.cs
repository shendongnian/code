    public void Receive()
    {
        while (tcpClient.Connected)
        {
            if (tcpClient.Available >= 0)
            {
                // Do something
            }
        }
    }
