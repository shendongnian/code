    private void ConnectCallback(IAsyncResult result) {
        ISocket client = (ISocket)result.AsyncState;
        client.EndConnect(result);
        connectDone.Set();
    }
