    protected Message PeekWithoutTimeout(MessageQueue q, Cursor cursor, PeekAction action)
    {
      Message ret = null;
      try
      {
         ret = q.Peek(new TimeSpan(1), cursor, action);
      }
      catch (MessageQueueException mqe)
      {
         if (!mqe.Message.ToLower().Contains("timeout"))
         {
            throw;
         }
      }
      return ret;
    }
    protected int GetMessageCount(MessageQueue q)
    {
      int count = 0;
      Cursor cursor = q.CreateCursor();
      Message m = PeekWithoutTimeout(q, cursor, PeekAction.Current);
      {
         count = 1;
         while ((m = PeekWithoutTimeout(q, cursor, PeekAction.Next)) != null)
         {
            count++;
         }
      }
	return count;
    }
