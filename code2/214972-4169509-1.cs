    void DeQueueMessages(ZClient client)
    {
        while(client.messageQueue.Count > 0)
        {
            Message m = client.messageQueue.Dequeue();
            ...
        }
    }
