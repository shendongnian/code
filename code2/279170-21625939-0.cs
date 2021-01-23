    public class SuperSortedSet<TValue> : ICollection<TValue>
    {
        private readonly SortedSet<Indexed<TValue>> _Container;
        private int _Index = 0;
        private IComparer<TValue> _Comparer;
 
        public SuperSortedSet(IComparer<TValue> comparer)
        {
            _Comparer = comparer;
            var c2 = new System.Linq.Comparer<Indexed<TValue>>((p0, p1) =>
            {
                var r = _Comparer.Compare(p0.Value, p1.Value);
                if (r == 0)
                {
                    if (p0.Index == -1
                        || p1.Index == -1)
                        return 0;
                    return p0.Index.CompareTo(p1.Index);
                    
                }
                else return r;
            });
            _Container = new SortedSet<Indexed<TValue>>(c2);
        } 
 
        public IEnumerator<TValue> GetEnumerator() { return _Container.Select(p => p.Value).GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public void Add(TValue item) { _Container.Add(Indexed.Create(_Index++, item)); }
        public void Clear() { _Container.Clear();}
        public bool Contains(TValue item) { return _Container.Contains(Indexed.Create(-1,item)); }
        public void CopyTo(TValue[] array, int arrayIndex)
        {
            foreach (var value in this)
            {
                if (arrayIndex >= array.Length)
                {
                    throw new ArgumentException("Not enough space in array");
                }
                array[arrayIndex] = value;
                arrayIndex++;
            }
        }
        public bool Remove(TValue item) { return _Container.Remove(Indexed.Create(-1, item)); }
        public int Count {
            get { return _Container.Count; }
        }
        public bool IsReadOnly {
            get { return false; }
        }
    }
