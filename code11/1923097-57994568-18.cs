    class OrderedMyObjectList : IList<MyObject>
    {
        private List<MyObject> innerList = new List<MyObject>();
    
        public MyObject this[int index]
        {
            get => this.innerList[index];
            set => throw new NotSupportedException("Cannot set an indexed item in a sorted list.");
        }
    
        public int Count => this.innerList.Count;
        public bool IsReadOnly => false;
    
        // Magic in the insert
        public void Add(MyObject item)
        {
            int index = innerList.BinarySearch(item, new MyObjectNameComparer());
            index = (index >= 0) ? index : ~index;
            innerList.Insert(index, item);
        }
    
        public void Clear() => this.innerList.Clear();
        public bool Contains(MyObject item) => this.innerList.Contains(item);
        public void CopyTo(MyObject[] array, int arrayIndex) => this.innerList.CopyTo(array);
        public IEnumerator<MyObject> GetEnumerator() => this.innerList.GetEnumerator();
        public int IndexOf(MyObject item) => this.innerList.IndexOf(item);
        public void Insert(int index, MyObject item) => throw new NotSupportedException("Cannot insert an indexed item in a sorted list.");
        public bool Remove(MyObject item) => this.innerList.Remove(item);
        public void RemoveAt(int index) => this.innerList.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
