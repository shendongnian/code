    byte[] buffer = new byte[4];
    clientStream.BeginRead(buffer, 0, buffer.Length, (IAsyncResult async) =>
    {
        int bytesRead = clientStream.EndRead(async);
        if (bytesRead == 4)
        {
            int result = BitConverter.ToInt32(buffer, 0);
            //..
        }
    }, clientStream);
