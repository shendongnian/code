    public class AsyncQueue<T>
    {
        private readonly object m_lock = new object();
        private bool m_finishedAdding = false;
        private readonly Queue<T> m_overflowQueue = new Queue<T>();
        private readonly Queue<TaskCompletionSource<T>> m_underflowQueue =
            new Queue<TaskCompletionSource<T>>();
        public bool IsCompleted
        {
            get { return m_finishedAdding && m_overflowQueue.Count == 0; }
        }
        public Task<T> DequeueAsync()
        {
            Task<T> result;
            lock (m_lock)
            {
                if (m_overflowQueue.Count > 0)
                    result = Task.FromResult(m_overflowQueue.Dequeue());
                else if (!m_finishedAdding)
                {
                    var tcs = new TaskCompletionSource<T>();
                    m_underflowQueue.Enqueue(tcs);
                    result = tcs.Task;
                }
                else
                    throw new InvalidOperationException();
            }
            return result;
        }
        public void Enqueue(T item)
        {
            lock (m_lock)
            {
                if (m_finishedAdding)
                    throw new InvalidOperationException();
                if (m_underflowQueue.Count > 0)
                {
                    var tcs = m_underflowQueue.Dequeue();
                    tcs.SetResult(item);
                }
                else
                    m_overflowQueue.Enqueue(item);
            }
        }
        public void FinishAdding()
        {
            lock (m_lock)
            {
                m_finishedAdding = true;
                while (m_underflowQueue.Count > 0)
                {
                    var tcs = m_underflowQueue.Dequeue();
                    tcs.SetException(new InvalidOperationException());
                }
            }
        }
    }
