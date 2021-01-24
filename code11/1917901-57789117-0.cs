    Channel<int> channel = Channel.CreateUnbounded<int>();
    ...
    ChannelReader<int> c = channel.Reader;
    while (await c.WaitToReadAsync())
    {
        if (await c.ReadAsync(out int item))
        {
             // process item...
        }
    }
