    SocketError error;
    byte[] buffer = new byte[512]; // Custom protocol max/fixed message size
    int c = this.Receive(buffer, 0, buffer.Length, SocketFlags.None, out error);
    if (error != SocketError.Success)
    {
        if(error == SocketError.MessageSize)
        {
            // The message was to large to fit in our buffer
        }
    }
