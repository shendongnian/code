    public async void SendMessage()
    {
        try {
            await socket.WriteAsync(buffer, 0, buffer.Length);
        } catch (...) {
            // handle it
       }
    }
