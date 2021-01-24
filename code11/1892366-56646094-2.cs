    public async Task SendBigBatchAsync<T>(IEnumerable<T> messages)
    {
        var brokeredMessages = messages.Select(m => new BrokeredMessage(m));
        var chunks = brokeredMessages.ChunkBy(bm => bm.Size, MaxServiceBusMessage);
        foreach (var chunk in chunks)
        {
            await client.SendBatchAsync(chunk);
        }
    }
