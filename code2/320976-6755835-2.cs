    private void OnConnect(IAsyncResult asyncResult)
    {
        if (OnConnectCompleted == null) return; // Check whether something is using this wrapper
        AsyncCompletedEventArgs args;
        try
        {
            Socket outSocket = (Socket) asyncResult.AsyncState;
                
            // Complete connection
            outSocket.EndConnect(asyncResult);
            args = new AsyncCompletedEventArgs(null);
            OnConnectCompleted(this, args);
        }
        catch (Exception e)
        {
            args = new AsyncCompletedEventArgs(e.Message);
            OnConnectCompleted(this, args);
        }
    }
