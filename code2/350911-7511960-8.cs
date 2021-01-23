    class AnotherClass
    {
        private ReadOnlyCollection<string> _readonlyList;
        public ReadOnlyCollection<string> ReadonlyList
        {
            get { return _readonlyList; }
        }
        private List<string> _list;
        public List<string> List
        {
            get { return _list; }
        }
        public AnotherClass()
        {
            _list = new List<string>();
            _readonlyList = new ReadOnlyCollection<string>(_list);
        }
    }
