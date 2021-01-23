    do
    {
       bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0);
       sb.Append(Encoding.ASCII.GetString(bytesReceived, 0, bytes));
    }
    while (bytes > 0);
