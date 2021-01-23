    // Shared queue.  Assuming that a tag is simply a string.
    BlockingCollection<string> TagQueue = new BlockingCollection<string>();
    
    // Tag reader threads (producers)
    while (!ShutdownMessageReceived)
    {
        string tag = GetTagFromReader(); // however that's done
        TagQueue.Add(tag);
    }
    
    // Processing thread (consumer)
    while (!ShutdownMessageReceived)
    {
        string tag = TagQueue.Take();
        // process the tag
    }
