    public void ReceiveCallback( IAsyncResult result, Object state)
    {
    
        var buffer = (byte[])result.AsyncState;
        int bytesRead = callback.EndReceive();
        memoryStream.Write (buffer, 0, bytesRead);
    }
