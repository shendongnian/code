    private Message Receive(MessageQueue queue)
    {
       try 
       {
          return queue.Receive(TimeSpan.Zero);
       }
       catch (MessageQueueException mqe)
       {
          if (mqe.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
             return null;
          throw;
       }
    }
