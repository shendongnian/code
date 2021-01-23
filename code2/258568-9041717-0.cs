        private List<SomeClass> _list;
        ...
        public override void Add(SomeClass instance)
        {
            mInstances.Add(instance);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (SomeClass instance in _list)
            {
                yield return instance;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
