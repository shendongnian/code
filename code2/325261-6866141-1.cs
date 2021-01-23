    private void ReceiveCallback(object sender, SocketAsyncEventArgs args)
    {
        lock (_sync) // re-entrant lock
        {
            // Fast fail: should not be receiving data if the client
            // is not in a receiving state.
            if (_clientState == EClientState.Receiving)
            {
                String host = (String)args.UserToken;
                 
                if (_asyncTask.Host == host && args.SocketError == SocketError.Success)
                {
                    try
                    {
                        Encoding encoding = Encoding.ASCII;
                        _asyncTask.BytesReceived = args.BytesTransferred;
                        _asyncTask.TotalBytesReceived += _asyncTask.BytesReceived;
                        _asyncTask.DocSource += encoding.GetString(_asyncTask.ReceiveBuffer, 0, _asyncTask.BytesReceived);
 
                        BeginReceive(); // <---- THIS IS WHAT YOU'RE MISSING
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("Error receiving data from: " + host);
                        Console.WriteLine("SocketException: {0} Error Code: {1}", e.Message, e.NativeErrorCode);
 
                        ChangeState(EClientState.Failed);
                    }
                }
                else if (_asyncTask.Host != host)
                {
                    Console.WriteLine("Warning: received a callback for {0}, but the client is currently working on {1}.",
                        host, _asyncTask.Host);
                }
                else
                {
                    Console.WriteLine("Socket Error: {0} when receiving from {1}",
                       args.SocketError,
                       _asyncTask.Host);
                    ChangeState(EClientState.Failed);
                }
            }
        }
    }
