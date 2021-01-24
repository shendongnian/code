    public async Task SendBigBatchAsync(IEnumerable<T> messages, Func<T, long> getSize)
    {
        var chunks = messages.ChunkBy(getSize, MaxServiceBusMessage);
        foreach (var chunk in chunks)
        {
            var brokeredMessages = chunk.Select(m => new BrokeredMessage(m));
            await client.SendBatchAsync(brokeredMessages);
        }
    }
    
    private const long MaxServiceBusMessage = 256000;
    private readonly QueueClient client;
