    while (numberOfBytesRead == 0)
    {          
        try
        {
            IsConnected();
            _socket.ReceiveTimeout = 5000;
            numberOfBytesRead = _socket.Receive(myReadBuffer, 0, myReadBuffer.Length, SocketFlags.None);
                            
        }
        catch (Exception e)
        {
            if (e.GetType() == typeof (LostConnection))
            {
                Status = SocketStatus.offline;
                throw;
            }
        }
    }
