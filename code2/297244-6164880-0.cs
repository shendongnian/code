    class MessageQueue
    {
    	public Queue<Type> m_queueSelectorQueue = new Queue<Type>();
    	public Dictionary<Type, object> m_queues = new Dictionary<Type, object>();
    	
    	public void Enqueue<T>(T message) where T : struct, IMessage
    	{
    		Queue<T> queue;
    		if (!m_queues.ContainsKey(typeof(T)))
    		{
    			 queue = new Queue<T>();
    			 m_queues[typeof(T)] = queue;
    		}
    		else
    			queue = (Queue<T>)m_queues[typeof(T)];
    		
    		queue.Enqueue(message);
    		m_queueSelectorQueue.Enqueue(typeof(T));
    	}
    }
