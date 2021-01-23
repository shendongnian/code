    public class CovariantIListAdapter<TBase, TDerived> : IList<TBase>
        where TDerived : TBase
    {
        private IList<TDerived> source;
        public CovariantIListAdapter(IList<TDerived> source)
        {
            this.source = source;
        }
        public IEnumerator<TBase> GetEnumerator()
        {
            foreach (var item in source)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(TBase item)
        {
            source.Add((TDerived) item);
        }
        public void Clear()
        {
            source.Clear();
        }
        public bool Contains(TBase item)
        {
            return source.Contains((TDerived) item);
        }
        public void CopyTo(TBase[] array, int arrayIndex)
        {
            foreach (var item in source)
                array[arrayIndex++] = item;
        }
        public bool Remove(TBase item)
        {
            return source.Remove((TDerived) item);
        }
        public int Count
        {
            get { return source.Count; }
        }
        public bool IsReadOnly
        {
            get { return source.IsReadOnly; }
        }
        public int IndexOf(TBase item)
        {
            return source.IndexOf((TDerived) item);
        }
        public void Insert(int index, TBase item)
        {
            source.Insert(index, (TDerived) item);
        }
        public void RemoveAt(int index)
        {
            source.RemoveAt(index);
        }
        public TBase this[int index]
        {
            get { return source[index]; }
            set { source[index] = (TDerived) value; }
        }
    }
