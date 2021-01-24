    private ManualResetEvent sendDone =
        new ManualResetEvent(false);
    private void SendData(byte[] data)
    {
        _clientSocket.BeginSend(data, 0, data.Length, 0,
            new AsyncCallback(SendCallback), null);
        sendDone.WaitOne();
        sendDone.Reset();
    }
    private void SendCallback(IAsyncResult ar)
    {
        try
        {
            int bytesSent = _clientSocket.EndSend(ar);
            sendDone.Set();
        }
        catch (Exception)
        {
            StartCoroutine(Reconnect());
        }
    }
