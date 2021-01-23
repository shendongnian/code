    public class DeviceDataQueue<TDevice, TData>
        : IProducerConsumerCollection<Tuple<TDevice, TData>>
    {
        private readonly object m_lockObject = new object();
        private readonly Dictionary<TDevice, TData> m_data
            = new Dictionary<TDevice, TData>();
        private readonly Queue<TDevice> m_queue = new Queue<TDevice>();
        //some obviously implemented methods elided, just make sure they are thread-safe
        public int Count { get { return m_queue.Count; } }
        public object SyncRoot { get { return this; } }
        public bool IsSynchronized { get { return true; } }
        public bool TryAdd(Tuple<TDevice, TData> item)
        {
            var device = item.Item1;
            var data = item.Item2;
            lock (m_lockObject)
            {
                if (!m_data.ContainsKey(device))
                    m_queue.Enqueue(device);
                m_data[device] = data;
            }
            return true;
        }
        public bool TryTake(out Tuple<TDevice, TData> item)
        {
            lock (m_lockObject)
            {
                if (m_queue.Count == 0)
                {
                    item = null;
                    return false;
                }
                var device = m_queue.Dequeue();
                var data = m_data[device];
                m_data.Remove(device);
                item = Tuple.Create(device, data);
                return true;
            }
        }
    }
