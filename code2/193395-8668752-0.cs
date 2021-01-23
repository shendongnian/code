    if (MessageQueue.Exists(fullQueuePath))
    {
        // FYI, GetMessageQueue() is a helper method we use to consolidate the code
        using (var messageQueue = GetMessageQueue(fullQueuePath))
        {
            var queueEnum = messageQueue.GetMessageEnumerator2();
            if (queueEnum.MoveNext())
            {
                // Queue not empty
            }
            else
            {
                // Queue empty
            }
        }
    }
