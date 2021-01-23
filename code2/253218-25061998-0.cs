    /// <summary>
    /// A lazy list for a fixed number of items where items are created on demand
    /// </summary>
    /// <typeparam name="T">The type of the object the list contains</typeparam>
    internal class LazyArray<T> : IList<T> where T : class
    {
        private readonly Func<int, T> constructor;
        private readonly IList<T> list;
        public LazyArray(int initialNumberOfItems, Func<int, T> constructor)
        {
            if (constructor == null) throw new ArgumentNullException("constructor");
            this.constructor = constructor;
            list = new T[initialNumberOfItems];
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            throw new NotSupportedException();
        }
        public void Clear()
        {
            throw new NotSupportedException();
        }
        public bool Contains(T item)
        {
            return list.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex + list.Count > array.Length)
                throw new ArgumentOutOfRangeException("arrayIndex");
            // Remember that we need to access the indexers to create the instance
            // so we can't just copy the list or the array may contain null entries
            for (var i = 0; i < list.Count; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }
        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }
        public int Count { get { return list.Count; } }
        public bool IsReadOnly { get { return true; } }
        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }
        public T this[int index]
        {
            get { return list[index] ?? (list[index] = constructor(index)); }
            set { throw new NotSupportedException(); }
        }
        private class Enumerator : IEnumerator<T>
        {
            private readonly LazyArray<T> baseList;
            private int index = -1;
            public Enumerator(LazyArray<T> baseList)
            {
                this.baseList = baseList;
            }
            public bool MoveNext()
            {
                return ++index < baseList.Count;
            }
            public void Reset()
            {
                index = -1;
            }
            public T Current
            {
                get { return baseList[index]; }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public void Dispose()
            {
            }
        }
    }
