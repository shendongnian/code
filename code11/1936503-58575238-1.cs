    class MyCollection : IEnumerable<MyObject>
    {
        private readonly IEnumerable<MyObject> _source;
        private readonly Lazy<ILookup<bool, MyObject>> _multiple2Lookup;
        private readonly Lazy<MyCollection> _even;
        private readonly Lazy<MyCollection> _odd;
        private readonly Lazy<ILookup<bool, MyObject>> _multiple3Lookup;
        private readonly Lazy<MyCollection> _multiple3;
        private readonly Lazy<MyCollection> _nonMultiple3;
        public MyCollection Even => _even.Value;
        public MyCollection Odd => _odd.Value;
        public MyCollection Multiple3 => _multiple3.Value;
        public MyCollection NonMultiple3 => _nonMultiple3.Value;
        public MyCollection(IEnumerable<MyObject> source)
        {
            _source = source;
            _multiple2Lookup = new Lazy<ILookup<bool, MyObject>>(
                () => _source.ToLookup(o => o.Number % 2 == 0));
            _even = new Lazy<MyCollection>(
                () => new MyCollection(_multiple2Lookup.Value[true]));
            _odd = new Lazy<MyCollection>(
                () => new MyCollection(_multiple2Lookup.Value[false]));
            _multiple3Lookup = new Lazy<ILookup<bool, MyObject>>(
                () => _source.ToLookup(o => o.Number % 3 == 0));
            _multiple3 = new Lazy<MyCollection>(
                () => new MyCollection(_multiple3Lookup.Value[true]));
            _nonMultiple3 = new Lazy<MyCollection>(
                () => new MyCollection(_multiple3Lookup.Value[false]));
        }
        public IEnumerator<MyObject> GetEnumerator() => _source.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
