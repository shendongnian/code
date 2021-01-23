    class genericCollection<T> : CollectionBase, IEnumerable<T>
    {
        public void add(T GenericObject)
        {
            this.List.Add(GenericObject);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.List.Cast<T>().GetEnumerator();
        }
    }
