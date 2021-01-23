	interface IMessageProcessor
	{
		void Process<T>(T message) where T : struct, IMessage;
	}
	
	class MessageQueue
	{
		abstract class TypedMessageQueue
		{
			public abstract void ProcessNext(IMessageProcessor messageProcessor);
		}
		
		class TypedMessageQueue<T> : TypedMessageQueue where T : struct, IMessage
		{
			Queue<T> m_queue = new Queue<T>();
			
			public void Enqueue(T message)
			{
				m_queue.Enqueue(message);
			}
		
			public override void ProcessNext(IMessageProcessor messageProcessor)
			{
				messageProcessor.Process(m_queue.Dequeue());
			}
		}
	
		Queue<Type> m_queueSelectorQueue = new Queue<Type>();
		Dictionary<Type, TypedMessageQueue> m_queues =
			new Dictionary<Type, TypedMessageQueue>();
	
		public void Enqueue<T>(T message) where T : struct, IMessage
		{
			TypedMessageQueue<T> queue;
			if (!m_queues.ContainsKey(typeof(T)))
			{
				queue = new TypedMessageQueue<T>();
				m_queues[typeof(T)] = queue;
			}
			else
				queue = (TypedMessageQueue<T>)m_queues[typeof(T)];
	
			queue.Enqueue(message);
			m_queueSelectorQueue.Enqueue(typeof(T));
		}
		
		public void ProcessNext(IMessageProcessor messageProcessor)
		{
			var type = m_queueSelectorQueue.Dequeue();
			m_queues[type].ProcessNext(messageProcessor);
		}
	}
