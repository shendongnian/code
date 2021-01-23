    public IncomingPacketQueue()
    {
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            Task.Factory.StartNew(Consume, TaskCreationOptions.LongRunning);
        }
    }
