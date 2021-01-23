    private static void OnReceiveData(IAsyncResult ar)
    {
        int bytesReceived = ((Socket) ar.AsyncState).EndReceive(ar);
        // process data...
    }
