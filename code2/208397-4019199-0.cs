    public class PriorityQueue<T> where T : class
    {
        private readonly object lockObject = new object();
        private readonly SortedList<int, Queue<T>> list = new SortedList<int, Queue<T>>();
        public int Count
        {
            get
            {
                lock (this.lockObject)
                {
                    return list.Sum(keyValuePair => keyValuePair.Value.Count);
                }
            }
        }
        public void Push(int priority, T item)
        {
            lock (this.lockObject)
            {
                if (!this.list.ContainsKey(priority))
                    this.list.Add(priority, new Queue<T>());
                this.list[priority].Enqueue(item);
            }
        }
        public T Pop()
        {
            lock (this.lockObject)
            {
                if (this.list.Count > 0)
                {
                    T obj = this.list.First().Value.Dequeue();
                    if (this.list.First().Value.Count == 0)
                        this.list.Remove(this.list.First().Key);
                    return obj;
                }
            }
            return null;
        }
        public T PopPriority(int priority)
        {
            lock (this.lockObject)
            {
                if (this.list.ContainsKey(priority))
                {
                    T obj = this.list[priority].Dequeue();
                    if (this.list[priority].Count == 0)
                        this.list.Remove(priority);
                    return obj;
                }
            }
            return null;
        }
        public IEnumerable<T> PopAllPriority(int priority)
        {
            List<T> ret = new List<T>();
            lock(this.lockObject)
            {
                if (this.list.ContainsKey(priority))
                {
                    while(this.list.ContainsKey(priority) && this.list[priority].Count > 0)
                        ret.Add(PopPriority(priority));
                    return ret;
                }
            }
            return ret;
        }
        public T Peek()
        {
            lock (this.lockObject)
            {
                if (this.list.Count > 0)
                    return this.list.First().Value.Peek();
            }
            return null;
        }
        public IEnumerable<T> PeekAll()
        {
            List<T> ret = new List<T>();
            lock (this.lockObject)
            {
                foreach (KeyValuePair<int, Queue<T>> keyValuePair in list)
                    ret.AddRange(keyValuePair.Value.AsEnumerable());
            }
            return ret;
        }
        public IEnumerable<T> PopAll()
        {
            List<T> ret = new List<T>();
            lock (this.lockObject)
            {
                while (this.list.Count > 0)
                    ret.Add(Pop());
            }
            return ret;
        }
    }
