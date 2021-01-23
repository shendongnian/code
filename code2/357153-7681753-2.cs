    class BlockingQueue<T>
    {
    	private Queue<T> _queue = new Queue<T>();
        public void Enqueue(T data)
        {
            if (data == null) throw new ArgumentNullException("data");
            lock (_queue)
            {
                _queue.Enqueue(data);
                Monitor.Pulse(_queue);
            }
    	}
        public T Dequeue()
        {
    	    lock (_queue)
    	    {
    	        while (_queue.Count == 0) Monitor.Wait(_queue);
    	        return _queue.Dequeue();
            }
        }
    }
