    private void AcceptClient()
    {
        try
        {
            using (StreamReader srReceiver = new StreamReader(tcpClient.GetStream()))
            {
                using (StreamWriter swSender = new StreamWriter(tcpClient.GetStream()))
                {
                    // ...
                }
            }
        }
        finally
        {
            tcpClient.Dispose();
        }
    }
