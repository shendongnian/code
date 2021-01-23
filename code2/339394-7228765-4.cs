    using (MessageQueue l_Queue = CreateQueue())
    {
        using (GZipStream stream = new GZipStream(l_QueueMessage.BodyStream, CompressionMode.Compress, true))
        {
            Formatter.Serialize(stream, message);
        }
    
        l_Queue.Send(l_QueueMessage);
    }
