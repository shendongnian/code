    do
    {
        bytes = socket.Receive(dataReceived, dataReceived.Length, 0);
        page = page + Encoding.ASCII.GetString(dataReceived, 0, bytes);
    }
    while (bytes > 0);
