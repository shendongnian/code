    void ReceiveAllMessages(Action<byte[]> messageReceived, Socket socket)
    {
        var currentMessage = new MemoryStream();
        var buffer = new byte[128];
        while (true)
        {
            var read = socket.Receive(buffer, 0, buffer.Length);
            if (read == 0)
                break;     // Connection closed
         
            for (var i = 0; i < read; i++)
            {
                var currentByte = buffer[i];
                if (currentByte == END_OF_MESSAGE)
                {
                    var message = currentMessage.ToByteArray();
                    messageReceived(message);
                    currentMessage = new MemoryStream();
                }
                else
                {
                    currentMessage.Write(currentByte);
                }
            }
        }
    }
