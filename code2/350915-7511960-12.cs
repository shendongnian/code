    class AnotherClass
    {
        private IIndexable<string> _readonlyList;
        public IIndexable<string> ReadonlyList
        {
            get { return _readonlyList; }
        }
        private List<SomeClass> _list;
        public List<SomeClass> List
        {
            get { return _list; }
        }
        public AnotherClass()
        {
            _list = new List<SomeClass>();
            _readonlyList = new ProjectionIndexable<SomeClass, string>
                 (_list.AsIndexable(), c => c.Age);
        }
    }
