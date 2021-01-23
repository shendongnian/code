    void DeQueueMessages(ZClient client)
    {
        foreach(Message m in client.messageList)
        {
            ...
        }
        messageList.Clear();
    }
