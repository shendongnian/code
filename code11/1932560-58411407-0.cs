    class EditOnlyCollection<T> : ICollection<T>
        {
            private readonly List<T> list;
            public EditOnlyCollection(IEnumerable<T> list)
            {
                this.list = list.ToList();
            }
            public int Count => list.Count;
            public bool IsReadOnly => true;
            public void Add(T item)
            {
                //nop
            }
            public void Clear()
            {
                //nop
            }
            public bool Contains(T item)
            {
                return list.Contains(item);
            }
            public void CopyTo(T[] array, int arrayIndex)
            {
                list.CopyTo(array, arrayIndex);
            }
            public IEnumerator<T> GetEnumerator()
            {
                return list.GetEnumerator();
            }
            public bool Remove(T item)
            {
                //nop
                return true; //have them think we removed an item
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return list.GetEnumerator();
            }
        }
