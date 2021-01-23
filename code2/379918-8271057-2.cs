    public void ReceiveCallback( IAsyncResult result)
    {
    
        var buffer = (byte[])result.AsyncState;
        int bytesRead = socket.EndReceive();
        memoryStream.Write (buffer, 0, bytesRead);//bytesRead may not be 1024!
    }
