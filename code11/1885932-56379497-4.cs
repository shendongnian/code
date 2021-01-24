    void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        var messagesFromQueue = DequeueUniqueMessages(messageQueue);
        DoWhateverWithTheMessages(messagesFromQueue);
    }
    IEnumerable<Message> DequeueUniqueMessages(ConcurrentQueue<Message> messageQueue)
    {
        var result = new HashSet<Message>();
        while (messageQueue.TryDequeue(out Message dequeued))
            result.Add(dequeued);
        return result;
    }
