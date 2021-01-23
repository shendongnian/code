    class ClassToResolve:IEnumerable<CollectionItem>
    {
        private List<CollectionItem> _coll;
        public ClassToResolve(IUnityContainer container)
        {
            _coll = container.ResolveAll<CollectionItem>();
        }
        public IEnumerator<CollectionItem> GetEnumerator()
        {
            return _coll.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(CollectionItem)
        {
            this._coll.Add(CollectionItem);
        }
    }
    now register you class
