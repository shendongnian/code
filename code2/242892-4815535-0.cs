    private void HandleConnection(IAsyncResult status)
    {
        SocketError socketRecieveError;
        _connectionSocket = _listener.EndAccept(status);
        _connectionSocket.BeginReceive(_receivedDataBuffer, 0, _receivedDataBuffer.Length, 0, out socketRecieveError, new AsyncCallback(HandleHandshake), null);
        if(socketRecieveError !=  SocketError.Success)
            _logger.Log("Socket error: " + socketRecieveError);
    }
    private void HandleHandshake(IAsyncResult status)
    {
        int bytesReceived = _connectionSocket.EndReceive(ar);
        ....
    }
