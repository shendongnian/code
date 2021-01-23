    var e = new SocketAsyncEventArgs();
    e.Completed += SocketReceiveCompleted;
    Socket.ReceiveAsync(e);
    private void SocketReceiveCompleted(object sender, SocketAsyncEventArgs e)
    {
        Offset += e.BytesTransferred;
        if (Offset > packet.Data.Length)
        {
            Socket.Close(); // or do whatever you need to do after your while loop
            return;
        }
        Array.Copy(e.Buffer, 0, packet.Data, Offset, e.BytesTransferred);
    }
