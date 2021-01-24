    public async Task ProcessInputAsync(T input)
    {
        foreach (var processor in m_processors)
        {
            await processor.Process(input));
        }
    }
Btw. `Process`, should be called `ProcessAsync`
