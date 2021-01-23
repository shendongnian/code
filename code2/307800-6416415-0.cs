    private void BeginReceive()
    {
        if ( _clientState == EClientState.Receiving)
        {
            if (_asyncTask.BytesReceived != 0 && _asyncTask.TotalBytesReceived <= _maxPageSize)
            {
                SocketAsyncEventArgs e = new SocketAsyncEventArgs();
                e.SetBuffer(_asyncTask.ReceiveBuffer, 0, _asyncTask.ReceiveBuffer.Length);
                e.Completed += new EventHandler<SocketAsyncEventArgs>(ReceiveCallback);
                e.UserToken = _asyncTask.Host;
 
                bool comletedAsync = false;
                try
                {
                    comletedAsync = _socket.ReceiveAsync(e);
                }
                catch (SocketException se)
                {
                    Console.WriteLine("Error receiving data from: " + _asyncTask.Host);
                    Console.WriteLine("SocketException: {0} Error Code: {1}", se.Message, se.NativeErrorCode);
 
                    ChangeState(EClientState.Failed);
                }
 
                if (!comletedAsync)
                {
                    // The call completed synchronously so invoke the callback ourselves
                    ReceiveCallback(this, e);
                }
            }
            else
            {
                //Console.WriteLine("Num bytes received: " + _asyncTask.TotalBytesReceived);
                ChangeState(EClientState.ReceiveDone);
            }
        }
    }
 
