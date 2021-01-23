    public class ZoneCollection : IList<Zone>, IList
    {
        private List<Zone> _list = new List<Zone>();
    
        public ZoneCollection()
        {
        }
    
        public int IndexOf(Zone item)
        {
            return _list.IndexOf(item);
        }
    
        public void Insert(int index, Zone item)
        {
            _list.Insert(index, item);
        }
    
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
    
        public Zone this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }
    
        public void Add(Zone item)
        {
            _list.Add(item);
        }
    
        public void Clear()
        {
            _list.Clear();
        }
    
        public bool Contains(Zone item)
        {
            return _list.Contains(item);
        }
    
        public void CopyTo(Zone[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
    
        public int Count
        {
            get { return _list.Count; }
        }
    
        public bool IsReadOnly
        {
            get { return ((IList)_list).IsReadOnly; }
        }
    
        public bool Remove(Zone item)
        {
            return _list.Remove(item);
        }
    
        public IEnumerator<Zone> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        int IList.Add(object value)
        {
            int index = Count;
            Add((Zone)value);
            return index;
        }
    
        bool IList.Contains(object value)
        {
            return Contains((Zone)value);
        }
    
        int IList.IndexOf(object value)
        {
            return IndexOf((Zone)value);
        }
    
        void IList.Insert(int index, object value)
        {
            Insert(index, (Zone)value);
        }
    
        bool IList.IsFixedSize
        {
            get { return ((IList)_list).IsFixedSize; }
        }
    
        bool IList.IsReadOnly
        {
            get { return ((IList)_list).IsReadOnly; }
        }
    
        void IList.Remove(object value)
        {
            Remove((Zone)value);
        }
    
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (Zone)value;
            }
        }
    
        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((Zone[])array, index);
        }
    
        bool ICollection.IsSynchronized
        {
            get { return ((ICollection)_list).IsSynchronized; }
        }
    
        object ICollection.SyncRoot
        {
            get { return ((ICollection)_list).SyncRoot; }
        }
    }
