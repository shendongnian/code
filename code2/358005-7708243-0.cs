    public class TupleDictionary<T1, T2, TValue> : Dictionary<Tuple<T1,T2>,TValue>
    {
        public TValue this[T1 t1, T2 t2]
        {
            get { return this[new Tuple<T1, T2>(t1, t2)]; }
            set { this[new Tuple<T1, T2>(t1,t2)] = value; }
        }
        public void Add(T1 t1, T2 t2, TValue value)
        {
            Add(new Tuple<T1, T2>(t1, t2), value);
        }
        public void Remove(T1 t1, T2 t2)
        {
            Remove(new Tuple<T1, T2>(t1, t2));
        }
        public bool ContainsKey(T1 t1, T2 t2)
        {
            return ContainsKey(new Tuple<T1, T2>(t1, t2));
        }
        public bool TryGetValue(T1 t1, T2 t2, out TValue value)
        {
            return TryGetValue(new Tuple<T1, T2>(t1, t2), out value);
        }
    }
