 public class ConcurrentList   
    {
        private long _i = 1;
        private ConcurrentDictionary<long, T> dict = new ConcurrentDictionary<long, T>();  
        public int Count()
        {
            return dict.Count;
        }
         public List<T> ToList()
         {
            return dict.Values.ToList();
         }
      
        public T this[int i]
        {
            get
            {
                long ii = dict.Keys.ToArray()[i];
                return dict[ii];
            }
        }
        public void Remove(T item)
        {
            T ov;
            var dicItem = dict.Where(c => c.Value.Equals(item)).FirstOrDefault();
            if (dicItem.Key > 0)
            {
                dict.TryRemove(dicItem.Key, out ov);
            }
            this.CheckReset();
        }
        public void RemoveAt(int i)
        {
            long v = dict.Keys.ToArray()[i];
            T ov;
            dict.TryRemove(v, out ov);
            this.CheckReset();
        }
        public void Add(T item)
        {
            dict.TryAdd(_i, item);
            _i++;
        }
        public IEnumerable<T> Where(Func<T, bool> p)
        {
            return dict.Values.Where(p);
        }
        public T FirstOrDefault(Func<T, bool> p)
        {
            return dict.Values.Where(p).FirstOrDefault();
        }
        public bool Any(Func<T, bool> p)
        {
            return dict.Values.Where(p).Count() > 0 ? true : false;
        }
        public void Clear()
        {
            dict.Clear();
        }
        private void CheckReset()
        {
            if (dict.Count == 0)
            {
                this.Reset();
            }
        }
        private void Reset()
        {
            _i = 1;
        }
    }
