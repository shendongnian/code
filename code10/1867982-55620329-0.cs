    public async void StartMessageLoopAsync()
    {
        while (true)
        {
            // read socket data asynchronously and populate the global DataBuffer
            await ReadDataAsync().ConfigureAwait(false);
            if (DataBuffer.Count == 0)
            {
                OnDataReceived();
            }
        }
    }
