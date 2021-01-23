    System.Messaging.MessageQueue queue = new MessageQueue(queueFormatName, false, true, QueueAccessMode.Send);
    
    System.Messaging.Message msg = new System.Messaging.Message();
    msg.BodyStream = new MemoryStream(buffer);
    
    queue.Send(msg, MessageQueueTransactionType.Single);
