    socket.BeginReceive(buffer, offset, count, SocketFlags.None, asyncResult =>
    {
        if(!asyncResult.AsyncWaitHandle.Wait(timeout))
        {
            // timeout..
        }
        read = socket.EndReceive(asyncResult);
    }, null);
