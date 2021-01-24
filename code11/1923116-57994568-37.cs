    class OrderedMyObjectCollection : ICollection<MyObject>
    {
        private List<MyObject> innerList = new List<MyObject>();
        public int Count => this.innerList.Count;
        public bool IsReadOnly => false;
        public void Add(MyObject item) => this.innerList.Add(item);
        public void Clear() => this.innerList.Clear();
        public bool Contains(MyObject item) => this.innerList.Contains(item);
    
        public void CopyTo(MyObject[] array, int arrayIndex)
        {
            // Could be more efficient...
            this.ToList().CopyTo(array);
        }
    
        // Magic in the ordered enumerator.
        public IEnumerator<MyObject> GetEnumerator() => this.innerList.OrderBy(x => x.Name).GetEnumerator();
        public bool Remove(MyObject item) => this.innerList.Remove(item);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
