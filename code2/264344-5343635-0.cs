    private Message Receive(MessageQueue queue)
    {
       try 
       {
          return queue.Receive(TimeSpan.Zero);
       }
       catch (MessageQueueException mqe)
       {
          if (mqe.ErrorCode == MessageQueueErrorCode.IOTimeout)
             return null;
          throw;
       }
    }
