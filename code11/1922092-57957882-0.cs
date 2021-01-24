    async Task RunConsumer()
    {
        foreach (var elem in _blockingCollectionFifoQueue.GetConsumingEnumerable())
        {
            try
            {
                await MethodDoingSomethingAsync(elem);
            }
            catch (MyException)
            {
                throw;
            }
        }
    }
