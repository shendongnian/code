    public sealed class RealtimeRunner : MarshalByRefObject
    {
      private BlockingCollection<Request> m_Queue = new BlockingCollection<Request>();
    
      public void QueueEvent(RealtimeProcessorMessage newRequest)
      {
        m_Queue.Add(new Request(newRequest _engine));
      }
    	    	
      private void EventLoop()
      {
        while (true)
    	{
          // This blocks until an item appears in the queue.
          Request request = m_Queue.Take();
          // Process the request here.
    	}
      }
    }
