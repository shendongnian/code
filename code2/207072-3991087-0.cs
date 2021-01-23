    private void AcceptClient()
    {
        using (StreamReader srReceiver = new StreamReader(tcpClient.GetStream()))
        {
            using (StreamWriter swSender = new StreamWriter(tcpClient.GetStream()))
            {
                // ...
            }
        }
    }
